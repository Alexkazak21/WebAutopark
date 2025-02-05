using Microsoft.AspNetCore.Mvc;
using WebAutopark.Models;
using WebAutopark.Services;

namespace WebAutopark.Controllers
{
    public class VehicleTypeController : Controller
    {
        private readonly ICRUDService<VehicleTypes> _vehicleTypeService;

        public VehicleTypeController(ICRUDService<VehicleTypes> vehicleTypeService)
        {
            _vehicleTypeService = vehicleTypeService;
        }

        public IActionResult Index()
        {
            var allTypes = _vehicleTypeService.GetAll();
            return View(allTypes);
        }

        [HttpPost]
        public IActionResult Create([FromBody] VehicleTypes type)
        {
            if (type == null)
            {
                return BadRequest();
            }

            _vehicleTypeService.Create(type);
            return Ok(new { success = true, message = "Vehicle Type added successfully!", data = type });
        }

        [HttpPost]
        public IActionResult Update([FromBody] VehicleTypes type)
        {
            if (type == null)
            {
                return Ok(new { success = false, message = "Vehicle Type is null!" });
            }

            if (_vehicleTypeService.Update(type))
            {
                return Ok(new { success = true, message = "Vehicle Type updated successfully!", data = type });
            }

            return Ok(new { success = false, message = "Vehicle Type wasn't updated!" });
        }

        [HttpDelete]
        public IActionResult Delete(int id)
        {
            if (_vehicleTypeService.Delete(id))
            {
                return Ok(new { success = true, message = "Vehicle Type deleted successfully!"});
            }

            return Ok(new { success = false, message = "Vehicle Type wasn't deleted!" });
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var types = _vehicleTypeService.GetAll();
            if (types == null)
            {
                return BadRequest("No types presented");
            }

            return Ok(new { success = false, message = "Vehicle Type was selected!", data = types });
        }
    }
}
