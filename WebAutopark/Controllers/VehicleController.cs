using Microsoft.AspNetCore.Mvc;
using WebAutopark.Services;
using WebAutopark.Models;
using Newtonsoft.Json;

namespace WebAutopark.Controllers;

public class VehicleController : Controller
{
    private readonly ICRUDService<Vehicle> _vehicleService;

    public VehicleController(ICRUDService<Vehicle> vehicleService)
    {
        _vehicleService = vehicleService;
    }

    public IActionResult Index()
    {
        var allVehicles = _vehicleService.GetAll();
        return View(allVehicles);
    }

    [HttpPost]
    public ActionResult Create([FromBody] object vehicle)
    {

        if (vehicle != null)
        {
            var newVehicle = JsonConvert.DeserializeObject<Vehicle>(vehicle.ToString());
            _vehicleService.Create(newVehicle);
            return Ok(new { success = true, message = "Vehicle added successfully!", data = vehicle });
        }

        return View(vehicle);
    }

    [HttpPost]
    public IActionResult Update([FromBody] Vehicle vehicle)
    {
        if (vehicle == null)
        {
            return Ok(new { success = false, message = "Vehicle is null!" });
        }

        if (_vehicleService.Update(vehicle))
        {
            return Ok(new { success = true, message = "Vehicle updated successfully!", data = vehicle });
        }

        return Ok(new { success = false, message = "Vehicle wasn't updated!" });
    }

    [HttpDelete]
    public IActionResult Delete(int id)
    {
        if (_vehicleService.Delete(id))
        {
            return Ok(new { success = true, message = "Vehicle deleted successfully!" });
        }

        return Ok(new { success = false, message = "Vehicle wasn't deleted!" });
    }

    [HttpGet]
    public IActionResult GetAll()
    {
        var vehicles = _vehicleService.GetAll();
        if (vehicles == null)
        {
            return BadRequest("No types presented");
        }

        return Ok(new { success = false, message = "Vehicle Type was selected!", data = vehicles });
    }
}
