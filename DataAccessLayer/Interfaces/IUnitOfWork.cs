using System;
using DataAccessLayer.Entities;

namespace DataAccessLayer.Interfaces
{
    public interface IUnitOfWork: IDisposable
    {
        IRepository<User> Players { get; }
        IRepository<Room> Games { get; }
        void Save();
    }
}