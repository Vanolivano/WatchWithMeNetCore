using System;
using System.Linq;
using System.Xml.Linq;
using BusinessLogicLayer.Domains;
using BusinessLogicLayer.EF;
using DataAccessLayer.UnitOfWork;

namespace BusinessLogicLayer
{
    internal static class Program
    {
        private static void Main()
        {
            using (IUnitOfWork uow = new UnitOfWork(new DatabaseContext()))
            {
                uow.GetRepository<Room>().Add(new Room{Name = "Столовая"});
                uow.GetRepository<User>().Add(new User{Login = "Vano", Password = "12123123", RoomId = 1});
                uow.Save();
                var users = uow.GetRepository<User>().GetAll().ToList();
                var rooms = uow.GetRepository<Room>().GetAll().ToList();
                //var users2 = uow.GetRepository<User>().GetAll(includeProperties: nameof(User.Rooms)).ToList();
            }
            Console.WriteLine("Hello World!");
        }
    }
}