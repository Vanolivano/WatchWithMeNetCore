using DataAccessLayer.EF;
using DataAccessLayer.Entities;
using DataAccessLayer.Interfaces;
using DataAccessLayer.Repository;

namespace DataAccessLayer
{
    public class UnitOfWork: IUnitOfWork
    {
        private WatchWithMeContext DataBase { get; }
        private UserRepository _usersRepository;
        private RoomRepository _roomsRepository;

        public UnitOfWork()
        {
            DataBase = new WatchWithMeContext();
        }

        public IRepository<User> Players
        {
            get
            {
                if (_usersRepository == null)
                    _usersRepository = new UserRepository(DataBase);
                return _usersRepository;
            }
        }
        public IRepository<Room> Games
        {
            get
            {
                if (_roomsRepository == null)
                    _roomsRepository = new RoomRepository(DataBase);
                return _roomsRepository;
            }
        }
       
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
