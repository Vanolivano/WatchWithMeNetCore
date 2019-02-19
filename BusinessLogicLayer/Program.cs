//using System;
//using System.Linq;
//using BusinessLogicLayer.Domains;
//using BusinessLogicLayer.EF;
//using DataAccessLayer.UnitOfWork;
//
//namespace BusinessLogicLayer
//{
//    internal static class Program
//    {
//        private static void Main()
//        {
//            using (IUnitOfWork uow = new UnitOfWork(new DatabaseContext()))
//            {
//                uow.GetRepository<Room>().Add(new Room{Name = "Столовая"});
//                uow.GetRepository<Room>().Add(new Room{Name = "Кухня"});
//                uow.GetRepository<Room>().Add(new Room());
//                uow.GetRepository<User>().Add(new User{Login = "Vano", Password = "12123123", RoomId = 1});
//                uow.GetRepository<User>().Add(new User{Login = "Ivan", Password = "qwerty"});
//                uow.Save();
//                var users = uow.GetRepository<User>().GetAll().ToList();
//                var rooms = uow.GetRepository<Room>().GetAll().ToList();
//                var rooms2 = uow.GetRepository<Room>().GetAll(x=>x.Name == "Столовая", q=>q.OrderBy(d=>d.Id), includeProperties: "Users").ToList();
//                
//            }
//            Console.WriteLine("Hello World!");
//        }
//    }
//}