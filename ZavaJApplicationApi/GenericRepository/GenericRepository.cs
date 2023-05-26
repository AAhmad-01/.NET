using Microsoft.EntityFrameworkCore;

namespace ZavaJApplicationApi.GenericRepository
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class

    {

        protected DbContext _context;
        protected DbSet<T> _dbSet;

        public GenericRepository(DbContext context)
        {
            _context = context;
            _dbSet = context.Set<T>();
    }


        public void Delete(T entity)
        {
            _context.Remove(entity);
        }

        public IEnumerable<T> GetAll()
        {
           return _dbSet.ToList();
        }

        public T GetById(int id) => _dbSet.Find(id);

        public T GetByEmail(string email) => _dbSet.Find(email);
        public void Insert(T entity)
        {
          _dbSet.Add(entity);
        }


        public void Update(T entity)
        {
            _dbSet.Attach(entity);
            _context.Entry(entity).State = EntityState.Modified;
        }
    }
}
