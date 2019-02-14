using System.Collections.Generic;
using DataAccessLayer.EF;
using DataAccessLayer.Entities;
using DataAccessLayer.Interfaces;

namespace DataAccessLayer.Repository
{
    public class UserRepository: IRepository<User>
    {
        private readonly DatabaseContext _dbContext;

        public UserRepository(DatabaseContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IEnumerable<User> ReadAll()
        {
            return _dbContext.Users;
        }

        public User Read(int id)
        {
            return _dbContext.Users.Find(id);
        }

        public void Create(User item)
        {
            _dbContext.Users.Add(item);
        }

        public void Update(User item)
        {
            _dbContext.Users.Update(item);
        }

        public void Delete(int id)
        {
            User game = _dbContext.Users.Find(id);
            if (game != null)
                _dbContext.Users.Remove(game);
        }
    }
}