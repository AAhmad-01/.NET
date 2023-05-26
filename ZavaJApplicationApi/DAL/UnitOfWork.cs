using System;
using ZavaJApplicationApi.DAL;
using ZavaJApplicationApi.GenericRepository;
using ZavaJApplicationApi.Model;

namespace ContosoUniversity.DAL
{
    public class UnitOfWork : IDisposable
    {
        private readonly IdentityDBContext _dbContext;

        public UnitOfWork(IdentityDBContext dbContext)
        {
            _dbContext = dbContext;
        }
        private GenericRepository<User>? userRepository;
        private GenericRepository<OtpTable>? otpRepository;

        public GenericRepository<User> UserRepository
        {
            get
            {

                if (this.userRepository== null)
                {
                    this.userRepository = new GenericRepository<User>(_dbContext);
                }
                return userRepository;
            }
        }

        public GenericRepository<OtpTable> OtpRepository
        {
            get
            {

                if (this.otpRepository == null)
                {
                    this.otpRepository = new GenericRepository<OtpTable>(_dbContext);
                }
                return otpRepository;
            }
        }

        public void Save()
        {
            _dbContext.SaveChanges();
        }

        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    _dbContext.Dispose();
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
}