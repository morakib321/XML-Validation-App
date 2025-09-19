using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace XmlValidationApp.Models
{
    public class XMLandSchemaFileUpload
    {
        [Display(Name = "XML File")]
        public IFormFile? XmlFile { get; set; }  

        [Display(Name = "Schema File")]
        public IFormFile? SchemaFile { get; set; }  
    }
}
