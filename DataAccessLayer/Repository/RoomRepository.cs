using System.Collections.Generic;
using DataAccessLayer.EF;
using DataAccessLayer.Entities;
using DataAccessLayer.Interfaces;

namespace DataAccessLayer.Repository
{
    public class RoomRepository: IRepository<Room>
    {
        private readonly DatabaseContext _dbContext;

        public RoomRepository(DatabaseContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IEnumerable<Room> ReadAll()
        {
            return _dbContext.Rooms;
        }

        public Room Read(int id)
        {
            return _dbContext.Rooms.Find(id);
        }

        public void Create(Room item)
        {
            _dbContext.Rooms.Add(item);
        }

        public void Update(Room item)
        {
            _dbContext.Rooms.Update(item);
        }

        public void Delete(int id)
        {
            Room item = _dbContext.Rooms.Find(id);
            if (item != null)
                _dbContext.Rooms.Remove(item);
        }
    }
}