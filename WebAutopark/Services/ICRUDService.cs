using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace WebAutopark.Services;

public interface ICRUDService<T> where T : class
{
    public List<T> GetAll();
    public bool Create(T entity);

    public bool Update(T entity);

    public bool Delete(int id);
}
