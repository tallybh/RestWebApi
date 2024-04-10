namespace RestWebApi.Contracts
{
    public interface IStudentRepository
    {
        IQueryable<Student> GetAll();

        Student Get(int id);
    }
}
