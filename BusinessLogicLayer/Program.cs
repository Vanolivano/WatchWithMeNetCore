using System;
using System.Linq;
using BusinessLogicLayer.Domains;
using DataAccessLayer;
using DataAccessLayer.EF;
using DataAccessLayer.UnitOfWork;

namespace BusinessLogicLayer
{
    internal static class Program
    {
        private static void Main()
        {
            using (IUnitOfWork uow = new UnitOfWork(new DatabaseContext()))
            {
                uow.GetRepository<DataAccessLayer.Entities.User>().Add(new User{Login = "Vano", Password = "12123123"});
                uow.Save();
                var users = uow.GetRepository<DataAccessLayer.Entities.User>().GetAll().ToList();
            }
            Console.WriteLine("Hello World!");
        }
    }
}