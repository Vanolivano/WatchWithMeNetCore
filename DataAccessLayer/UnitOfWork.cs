using DataAccessLayer.EF;
using DataAccessLayer.Entities;
using DataAccessLayer.Interfaces;
using DataAccessLayer.Repositories;

namespace DataAccessLayer
{
    public class UnitOfWork: IUnitOfWork
    {
        private DatabaseContext DataBase { get; }
        private UserRepository _usersRepository;
        private RoomRepository _roomsRepository;

        public UnitOfWork()
        {
            DataBase = new DatabaseContext();
        }

        public IRepository<User> Users
        {
            get
            {
                if (_usersRepository == null)
                    _usersRepository = new UserRepository(DataBase);
                return _usersRepository;
            }
        }
        public IRepository<Room> Rooms
        {
            get
            {
                if (_roomsRepository == null)
                    _roomsRepository = new RoomRepository(DataBase);
                return _roomsRepository;
            }
        }
//        public IRepository<T> GetRepository<T>() where T : class
//        {
//            
//                if (_roomsRepository == null)
//                    _roomsRepository = new RoomRepository(DataBase);
//                return _roomsRepository;
//                return new RepositoryFactory<T>(_ctx).GetRepositoryInstance();
//            
//        }
       
        public void Save()
        {
            DataBase.SaveChanges();
        }

        public void Dispose()
        {
            DataBase.Dispose();
        }
    }
}
