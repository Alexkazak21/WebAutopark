using Microsoft.AspNetCore.Mvc;

namespace WebAutopark.Controllers
{
    public class ComponentController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
