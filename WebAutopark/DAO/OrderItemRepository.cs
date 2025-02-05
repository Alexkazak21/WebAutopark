using WebAutopark.DAO.Interfaces;

namespace WebAutopark.DAO;

public class OrderItemRepository : IRepository<OrderItems>
{
    private string _connectionString = string.Empty;

    public OrderItemRepository(string connectionString)
    {
        _connectionString = connectionString;
    }

    public void Create(OrderItems entity)
    {
        throw new NotImplementedException();
    }

    public void Delete(int id)
    {
        throw new NotImplementedException();
    }

    public List<OrderItems> GetAll()
    {
        throw new NotImplementedException();
    }

    public OrderItems GetValue(int id)
    {
        throw new NotImplementedException();
    }

    public void Update(OrderItems entity)
    {
        throw new NotImplementedException();
    }
}
