using WebAutopark.DAO;
using WebAutopark.DAO.Interfaces;
using WebAutopark.Models;
using static Dapper.SqlMapper;

namespace WebAutopark.Services;

public class VehicleService : ICRUDService<Vehicle>
{
    private readonly IRepository<Vehicle> _vehicleRepository;

    public VehicleService(IRepository<Vehicle> vehicleRepository)
    {
        _vehicleRepository = vehicleRepository;
    }

    public bool Create(Vehicle entity)
    {
        if (entity == null)
        {
            return false;
        }

        _vehicleRepository.Create(entity);

        return true;
    }

    public bool Delete(int id)
    {
        try
        {
            _vehicleRepository.Delete(id);
            return true;
        }
        catch (Exception ex)
        {
            return false;
        }
    }

    public List<Vehicle> GetAll()
    {
        return _vehicleRepository.GetAll();
    }

    public bool Update(Vehicle entity)
    {
        if (entity == null)
        {
            return false;
        }

        try
        {
            _vehicleRepository.Update(entity);
            return true;
        }
        catch (Exception ex)
        {
            return false;
        }

    }
}
