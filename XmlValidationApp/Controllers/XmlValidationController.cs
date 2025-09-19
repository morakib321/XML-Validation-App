using Microsoft.AspNetCore.Mvc;
using System.IO;
using System.Xml;
using System.Xml.Schema;
using XmlValidationApp.Models;

namespace XmlValidationApp.Controllers
{
    public class XmlValidationController : Controller
    {
        
        public IActionResult Index()
        {
            return View();
        }

        
        [HttpPost]
        public IActionResult ValidateXml(XMLandSchemaFileUpload model)
        {
            if (ModelState.IsValid)
            {
                
                if (model.XmlFile == null || model.SchemaFile == null)
                {
                    ViewBag.Message = "Both XML and Schema files are required.";
                    return View("Index", model);
                }

                try
                {
                    
                    var schemaPath = Path.Combine(Path.GetTempPath(), model.SchemaFile.FileName);
                    var xmlPath = Path.Combine(Path.GetTempPath(), model.XmlFile.FileName);

                    using (var schemaStream = new FileStream(schemaPath, FileMode.Create))
                    {
                        model.SchemaFile.CopyTo(schemaStream);
                    }

                    using (var xmlStream = new FileStream(xmlPath, FileMode.Create))
                    {
                        model.XmlFile.CopyTo(xmlStream);
                    }

                    
                    XmlSchemaSet schemaSet = new XmlSchemaSet();
                    schemaSet.Add(null, schemaPath);

                    XmlReaderSettings settings = new XmlReaderSettings
                    {
                        ValidationType = ValidationType.Schema,
                        Schemas = schemaSet
                    };

                    settings.ValidationEventHandler += (sender, e) =>
                    {
                        
                        throw new XmlSchemaValidationException(e.Message);
                    };

                    
                    using (XmlReader reader = XmlReader.Create(xmlPath, settings))
                    {
                        while (reader.Read()) { }
                    }

                    ViewBag.Message = "XML file is valid according to the schema.";
                }
                catch (XmlSchemaValidationException ex)
                {
                    ViewBag.Message = $"XML validation error: {ex.Message}";
                }
                catch (Exception ex)
                {
                    ViewBag.Message = $"An error occurred: {ex.Message}";
                }
            }
            else
            {
                ViewBag.Message = "Please upload both XML and Schema files.";
            }

            
            return View("Index", model);
        }
    }
}
