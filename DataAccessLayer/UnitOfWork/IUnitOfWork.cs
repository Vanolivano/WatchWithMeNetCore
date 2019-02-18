using System;
using System.Threading.Tasks;
using DataAccessLayer.RepositoryBase;

namespace DataAccessLayer.UnitOfWork
{
    public interface IUnitOfWork: IDisposable
    {
        IRepositoryBase<T> GetRepository<T>() where T : class;
        int Save();
        Task<int> SaveASync();
    }
}