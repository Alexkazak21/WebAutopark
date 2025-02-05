using Microsoft.Data.SqlClient;
using System.Data;
using WebAutopark.DAO.Interfaces;
using Dapper;
using static Dapper.SqlMapper;
using WebAutopark.Models;
using WebAutopark.Data;

namespace WebAutopark.DAO;

public class VehicleRepository : IRepository<Vehicle>
{
    private const string VEHICLE_ADDRESS = "WebAutoparkDB.dbo.Vehicles";
    private string _connectionString = string.Empty;

    public VehicleRepository(string connectionString)
    {
        _connectionString = connectionString;
    }

    public void Create(Vehicle entity)
    {
        using (IDbConnection db = new SqlConnection(_connectionString))
        {            
            var sqlQuery = $"INSERT INTO {VEHICLE_ADDRESS} (VehicleId, VehicleTypeId, Model, RegistrationNumber, Weight, Year, Mileage, Color, FuelConsumption)" +
                "VALUES (@VehicleId, @VehicleTypeId, @Model, @RegistrationNumber, @Weight, @Year, @Mileage, @Color, @FuelConsumption)";
            db.Execute(sqlQuery, entity);
        }
    }

    public void Delete(int id)
    {
        using (IDbConnection db = new SqlConnection(_connectionString))
        {
            var sqlQuery = $"DELETE FROM {VEHICLE_ADDRESS} WHERE VehicleId = @{nameof(Vehicle.VehicleId)}";
            db.Execute(sqlQuery, new { id });
        }
    }

    public List<Vehicle> GetAll()
    {
        using (IDbConnection db = new SqlConnection(_connectionString))
        {
            return db.Query<Vehicle>($"SELECT * FROM {VEHICLE_ADDRESS}").ToList();
        }
    }

    public Vehicle GetValue(int id)
    {
        using (IDbConnection db = new SqlConnection(_connectionString))
        {
            var sqlQuery = $"SELECT * FROM {VEHICLE_ADDRESS} WHERE VehicleId = @{nameof(Vehicle.VehicleId)}";
            return db.Query<Vehicle>(sqlQuery, new { id }).FirstOrDefault();
        }
    }

    public void Update(Vehicle entity)
    {
        using (IDbConnection db = new SqlConnection(_connectionString))
        {
            var sqlQuery = $"UPDATE {VEHICLE_ADDRESS} SET VehicleTypeId = @VehicleTypeId, Model = @Model, RegistrationNumber = @RegistrationNumber, Weight = @Weight, Year = @Year, Mileage = @Mileage, Color = @Color, FuelConsumption = @FuelConsumption WHERE VehicleId = @VehicleId";
            db.Execute(sqlQuery, entity);
        }
    }
}
