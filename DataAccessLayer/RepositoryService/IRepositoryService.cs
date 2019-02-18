using System;
using DataAccessLayer.RepositoryBase;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer.RepositoryService
{
    public interface IRepositoryService
    {
        DbContext DbContext { get; set; }

        IRepositoryBase<T> GetGenericRepository<T>() where T : class;

        T GetCustomRepository<T>(Func<DbContext, object> factory = null) where T : class;
    }
}