using Microsoft.AspNetCore.Mvc;

namespace XmlValidationApp.Controllers
{
    public class HomeController : Controller
    {
        
        public IActionResult Index()
        {
            return View(); 
        }
    }
}
