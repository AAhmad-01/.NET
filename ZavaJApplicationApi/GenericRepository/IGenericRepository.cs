namespace ZavaJApplicationApi.GenericRepository
{
    public interface IGenericRepository<T> where T : class
    {
        IEnumerable<T> GetAll();
        T GetById(int id);

        T GetByEmail(string email);
        void Insert(T entity);
        void Update(T entity);
        void Delete(T entity);
 

    }
}
