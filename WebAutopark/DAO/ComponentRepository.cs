using Dapper;
using Microsoft.Data.SqlClient;
using System.ComponentModel;
using System.Data;
using WebAutopark.DAO.Interfaces;
using WebAutopark.Models;

namespace WebAutopark.DAO;

public class ComponentRepository : IRepository<Components>
{
    private string _connectionString = string.Empty;

    public ComponentRepository(string connectionString)
    {
        _connectionString = connectionString;
    }

    public void Create(Components entity)
    {
        using (IDbConnection db = new SqlConnection(_connectionString))
        {
            var sqlQuery = "INSERT INTO Components (ComponentId, Name) VALUES(@ComponentId, @Name)";
            db.Execute(sqlQuery, entity);
        }
    }

    public void Delete(int id)
    {
        using (IDbConnection db = new SqlConnection(_connectionString))
        {
            var sqlQuery = $"DELETE FROM Components WHERE ComponentId = @{nameof(Components.ComponentId)}";
            db.Execute(sqlQuery, new { id });
        }
    }

    public List<Components> GetAll()
    {
        using (IDbConnection db = new SqlConnection(_connectionString))
        {
            return db.Query<Components>("SELECT * FROM Components").ToList();
        }
    }

    public Components GetValue(int id)
    {
        using (IDbConnection db = new SqlConnection(_connectionString))
        {
            var sqlQuery = $"SELECT * FROM Components WHERE ComponentId = @{nameof(Components.ComponentId)}";
            return db.Query<Components>(sqlQuery, new { id }).FirstOrDefault();
        }
    }

    public void Update(Components entity)
    {
        using (IDbConnection db = new SqlConnection(_connectionString))
        {
            var sqlQuery = "UPDATE Components SET Name = @Name WHERE ComponentId = @ComponentId";
            db.Execute(sqlQuery, entity);
        }
    }
}
