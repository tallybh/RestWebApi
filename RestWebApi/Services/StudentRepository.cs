using RestWebApi.Contracts;

namespace RestWebApi.Services;

public class StudentRepository : IStudentRepository, IDisposable
{
    public void Dispose()
    {
        throw new NotImplementedException();
    }

    public Student Get(int id)
    {
        throw new NotImplementedException();
    }

    public IQueryable<Student> GetAll()
    {
        throw new NotImplementedException();
    }
}
