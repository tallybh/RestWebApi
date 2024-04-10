namespace RestWebApi.Contracts
{
    public interface IGenericRepository<T>
    {
        IEnumerable<T> GetAll();
        T GetById(object id);

        void Insert(T obj);


    }
}
