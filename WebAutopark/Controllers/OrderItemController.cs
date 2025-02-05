using Microsoft.AspNetCore.Mvc;

namespace WebAutopark.Controllers
{
    public class OrderItemController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
