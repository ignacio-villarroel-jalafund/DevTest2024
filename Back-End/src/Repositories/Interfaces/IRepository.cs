public interface IRepository<T>
{
    Task<T?> Create(T item);
    Task<T?> Update(int id, T item);
    Task<bool> Delete(int id);
    Task<T?> GetById(int id);
    Task<List<T>> GetAll();
}