using Microsoft.EntityFrameworkCore;
using RestWebApi.Contracts;

namespace RestWebApi.Services;

public class GenericRepository<T> :IDisposable, IGenericRepository<T> where T : class
{

    //The following variable is going to hold the EmployeeDBContext instance
    private AppDbContext _context = null;
    //The following Variable is going to hold the DbSet Entity
    private DbSet<T> table = null;
    //Using the Parameterless Constructor, 
    //we are initializing the context object and table variable
    public GenericRepository()
    {
        this._context = new AppDbContext();
        //Whatever class name we specify while creating the instance of GenericRepository
        //That class name will be stored in the table variable
        table = _context.Set<T>();
    }
    //Using the Parameterized Constructor, 
    //we are initializing the context object and table variable
    public GenericRepository(AppDbContext _context)
    {
        this._context = _context;
        table = _context.Set<T>();
    }
    //This method will return all the Records from the table
    public  IEnumerable<T> GetAll()
    { 
        return table.ToList();
    }
    //This method will return the specified record from the table
    //based on the ID which it received as an argument
    public T GetById(object id)
    {
        return table.Find(id);
    }
    //This method will Insert one object into the table
    //It will receive the object as an argument which needs to be inserted into the database
    public void Insert(T obj)
    {
        //It will mark the Entity state as Added State
        table.Add(obj);
    }
    //This method is going to update the record in the table
    //It will receive the object as an argument
    public void Update(T obj)
    {
        //First attach the object to the table
        table.Attach(obj);
        //Then set the state of the Entity as Modified
        _context.Entry(obj).State = EntityState.Modified;
    }
    //This method is going to remove the record from the table
    //It will receive the primary key value as an argument whose information needs to be removed from the table
    public void Delete(object id)
    {
        //First, fetch the record from the table
        T existing = table.Find(id);
        //This will mark the Entity 
        table.Remove(existing);
    }

    public void Save()
    {
        _context.SaveChanges();
    }

    private bool disposed = false;

    protected virtual void Dispose(bool disposing)
    {
        if (!this.disposed)
        {
            if (disposing)
            {
                _context.Dispose();
            }
        }
        this.disposed = true;
    }

    public void Dispose()
    {
        Dispose(true);
        GC.SuppressFinalize(this);
    }

  
}
