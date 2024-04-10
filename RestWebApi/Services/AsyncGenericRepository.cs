using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using RestWebApi.Contracts;

namespace RestWebApi.Services;

public class AsyncGenericRepository<T> :  IAsyncGenericRepository<T> where T : BaseEntity
{
    //The following variable is going to hold the EmployeeDBContext instance
    private AppDbContext _context = null;
    //The following Variable is going to hold the DbSet Entity
    private DbSet<T> table = null;

    public AsyncGenericRepository(AppDbContext _context)
    {
        this._context = _context;
        table = _context.Set<T>();
    }

    public Task<List<T>> GetAllAsync()
    {
        return table.ToListAsync();
    }


    public Task<T> GetByIdAsync(object id)
    {
        return Task.FromResult(table.Find(id));
    }

    
    public Task UpdateAsync(T entity)
    {
        table.Update(entity);
        return Task.CompletedTask;
    }

    public Task DeleteAsync(T entity)
    {
        table.Remove(entity);
        return Task.CompletedTask;
    }

    public Task DeleteAsync(int id)
    {

        var entityToDelete = table.FirstOrDefault(x => x.Id == id);
        if (entityToDelete != null)
        {
            this.table.Remove(entityToDelete);
            return Task.CompletedTask;
        }
        else
        {
            return null;
        }

    }

    public async Task<T> InsertAsync(T entity)
    {
        await table.AddAsync(entity);
        return entity;
    }


}



