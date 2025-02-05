using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Runtime.CompilerServices;
using WebAutopark.Models;
using WebAutopark.Services;

namespace WebAutopark.Controllers
{
    public class OrderController : Controller
    {
        private readonly ICRUDService<Orders> _orderService;

        public OrderController(ICRUDService<Orders> orderService)
        {
            _orderService = orderService;
        }
        public IActionResult Index()
        {
            var orders = _orderService.GetAll();
            return View(orders);
        }

        [HttpPost]
        public ActionResult Create([FromBody] object order)
        {
            if (order != null)
            {
                var newOrder = JsonConvert.DeserializeObject<Orders>(order.ToString());
                _orderService.Create(newOrder);
                return Ok(new { success = true, message = "Vehicle added successfully!", data = order });
            }

            return View(order);
        }
    }
}
