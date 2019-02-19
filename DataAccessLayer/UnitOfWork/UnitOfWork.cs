using System;
using System.Threading.Tasks;
using DataAccessLayer.RepositoryBase;
using DataAccessLayer.RepositoryService;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer.UnitOfWork
{
    public class UnitOfWork: IUnitOfWork
    {
        private readonly DbContext _dbContext;
        
        private readonly IRepositoryService _repositoryService;

        public UnitOfWork(DbContext dbContext)
        {
            _dbContext = dbContext;

            if (_repositoryService == null)
            {
                _repositoryService = new RepositoryServiceImpl();
            }

            _repositoryService.DbContext = _dbContext;
        }
        int IUnitOfWork.Save()
        {
            return _dbContext.SaveChanges();
        }

        Task<int> IUnitOfWork.SaveASync()
        {
            return _dbContext.SaveChangesAsync();
        }

        void IDisposable.Dispose()
        {
            _dbContext.Dispose();
        }

        IRepositoryBase<T> IUnitOfWork.GetRepository<T>()
        {
            return _repositoryService.GetGenericRepository<T>();
        }
    }
}
