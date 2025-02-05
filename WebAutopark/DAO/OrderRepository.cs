using Microsoft.Data.SqlClient;
using System.Data;
using WebAutopark.DAO.Interfaces;
using WebAutopark.Models;
using Dapper;
using Newtonsoft.Json;

namespace WebAutopark.DAO;

public class OrderRepository : IRepository<Orders>
{
    private const string ORDER_ADDRESS = "WebAutoparkDB.dbo.Orders";
    private string _connectionString = string.Empty;

    public OrderRepository(string connectionString)
    {
        _connectionString = connectionString;
    }

    public void Create(Orders entity)
    {
        using (IDbConnection db = new SqlConnection(_connectionString))
        {
            var sqlQuery = $"INSERT INTO {ORDER_ADDRESS} (OrderId, VehicleId, Date) VALUES(@OrderId, @VehicleId, @Date)";
            var t = entity.Date.ToString("yyyy-MM-dd");
            db.Execute(sqlQuery, new { OrderId = entity.OrderId, VehicleId = entity.VehicleId, Date = t });
        }
    }

    public void Delete(int orderId)
    {
        using (IDbConnection db = new SqlConnection(_connectionString))
        {
            var sqlQuery = $"DELETE FROM {ORDER_ADDRESS} WHERE OrderId = @{nameof(Orders.OrderId)}";
            db.Execute(sqlQuery, new { orderId });
        }
    }

    public List<Orders> GetAll()
    {
        using (IDbConnection db = new SqlConnection(_connectionString))
        {
            return db.Query<Orders>($"SELECT * FROM {ORDER_ADDRESS}").ToList();
        }
    }

    public Orders GetValue(int id)
    {
        throw new NotImplementedException();
    }

    public void Update(Orders entity)
    {
        using (IDbConnection db = new SqlConnection(_connectionString))
        {
            var sqlQuery = $"UPDATE {ORDER_ADDRESS} SET VehicleId = @VehicleId, Date = @Date, WHERE OrderId = @OrderId";
            db.Execute(sqlQuery, entity);
        }
    }
}
