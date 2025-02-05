namespace WebAutopark.DAO.Interfaces;

public interface IRepository<T> where T : class
{
    void Create(T entity);

    void Delete(int id);

    T GetValue(int id);

    List<T> GetAll();

    void Update(T entity);
}
