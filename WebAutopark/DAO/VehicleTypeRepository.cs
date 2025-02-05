using Microsoft.Data.SqlClient;
using System.Data;
using WebAutopark.DAO.Interfaces;
using WebAutopark.Models;
using Dapper;

namespace WebAutopark.DAO;

public class VehicleTypeRepository : IRepository<VehicleTypes>
{
    private const string VEHICLE_TYPE_ADDRESS = "WebAutoparkDB.dbo.VehicleTypes";
    private string _connectionString = string.Empty;

    public VehicleTypeRepository(string connectionString)
    {
        _connectionString = connectionString;
    }

    public void Create(VehicleTypes entity)
    {
        using (IDbConnection db = new SqlConnection(_connectionString))
        {
            var sqlQuery = $"INSERT INTO {VEHICLE_TYPE_ADDRESS} (VehicleTypeId, Name, TaxCoefficient) VALUES(@VehicleTypeId,@Name, @TaxCoefficient)";
            db.Execute(sqlQuery, entity);
        }
    }

    public void Delete(int VehicleTypeId)
    {
        using (IDbConnection db = new SqlConnection(_connectionString))
        {
            var sqlQuery = $"DELETE FROM {VEHICLE_TYPE_ADDRESS} WHERE VehicleTypeId = @{nameof(VehicleTypes.VehicleTypeId)}";
            db.Execute(sqlQuery, new { VehicleTypeId });
        }
    }

    public List<VehicleTypes> GetAll()
    {
        using (IDbConnection db = new SqlConnection(_connectionString))
        {
            return db.Query<VehicleTypes>($"SELECT * FROM {VEHICLE_TYPE_ADDRESS}").ToList();
        }
    }

    public VehicleTypes GetValue(int id)
    {
        throw new NotImplementedException();
    }

    public void Update(VehicleTypes entity)
    {
        using (IDbConnection db = new SqlConnection(_connectionString))
        {
            var sqlQuery = $"UPDATE {VEHICLE_TYPE_ADDRESS} SET Name = @Name, TaxCoefficient = @TaxCoefficient WHERE VehicleTypeId = @VehicleTypeId";
            db.Execute(sqlQuery, entity);
        }
    }
}
