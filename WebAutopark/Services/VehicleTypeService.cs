using WebAutopark.DAO.Interfaces;
using WebAutopark.Models;

namespace WebAutopark.Services;

public class VehicleTypeService : ICRUDService<VehicleTypes>
{
    private readonly IRepository<VehicleTypes> _vehicleTypesRepository;

    public VehicleTypeService(IRepository<VehicleTypes> vehicleTypesRepository)
    {
        _vehicleTypesRepository = vehicleTypesRepository;
    }

    public bool Create(VehicleTypes entity)
    {
        _vehicleTypesRepository.Create(entity);
        return true;
    }

    public bool Delete(int id)
    {
        try
        {
            _vehicleTypesRepository.Delete(id);
            return true;
        }
        catch (Exception ex) 
        {
            return false;
        }
    }

    public List<VehicleTypes> GetAll()
    {
        return _vehicleTypesRepository.GetAll();
    }

    public bool Update(VehicleTypes entity)
    {
        try
        {
            _vehicleTypesRepository.Update(entity);
            return true;
        }
        catch (Exception ex)
        {
            return false;
        }        
    }
}

