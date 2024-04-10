namespace RestWebApi.Contracts;

public interface IAsyncGenericRepository<T>
{

    Task<List<T>> GetAllAsync();
    Task<T> GetByIdAsync(object id);
    Task<T> InsertAsync(T entity);
    Task DeleteAsync(int id);
    Task UpdateAsync(T entity);

}
