using Microsoft.EntityFrameworkCore;

namespace ZavaJApplicationApi.DAL
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly DbContext _context;
        private UnitOfWork(DbContext context)
        {
            _context = context;

        }

        public void Dispose()
        {
            _context.Dispose();
        }

        public void saveChanges()
        {
            _context.Dispose();
        }
    }
}
