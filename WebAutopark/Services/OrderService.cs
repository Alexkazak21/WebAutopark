using System.Runtime.CompilerServices;
using WebAutopark.DAO;
using WebAutopark.DAO.Interfaces;
using WebAutopark.Models;
using static Dapper.SqlMapper;

namespace WebAutopark.Services;

public class OrderService : ICRUDService<Orders>
{
    private readonly IRepository<Orders> _orderRepository;

    public OrderService(IRepository<Orders> orderRepository)
    {
        _orderRepository = orderRepository;
    }

    public bool Create(Orders entity)
    {
        if (entity == null)
        {
            return false;
        }

        try
        {
            _orderRepository.Create(entity);
            return true;
        }
        catch (Exception ex)
        {
            return false;
        }
    }

    public bool Delete(int id)
    {
        try
        {
            _orderRepository.Delete(id);
            return true;
        }
        catch (Exception ex)
        {
            return false;
        }
    }

    public List<Orders> GetAll()
    {
        return _orderRepository.GetAll();
    }

    public bool Update(Orders entity)
    {
        if (entity == null)
        {
            return false;
        }

        try
        {
            _orderRepository.Update(entity);
            return true;
        }
        catch (Exception ex)
        {
            return false;
        }
    }
}
