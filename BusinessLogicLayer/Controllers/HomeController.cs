using System.Collections.Generic;
using System.Linq;
using BusinessLogicLayer.Domains;
using BusinessLogicLayer.EF;
using DataAccessLayer.UnitOfWork;
using Microsoft.AspNetCore.Mvc;

namespace BusinessLogicLayer.Controllers
{

    public class HomeController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public HomeController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpGet]
        public ActionResult<List<AppUser>> GetAllUsers()
        {
            _unitOfWork.GetRepository<Room>().Add(new Room {Name = "Столовая"});
            _unitOfWork.GetRepository<Room>().Add(new Room {Name = "Кухня"});
//          uow.GetRepository<Room>().Add(new Room());
//          uow.GetRepository<User>().Add(new User{Login = "Vano", Password = "12123123", RoomId = 1});
//          uow.GetRepository<User>().Add(new User{Login = "Ivan", Password = "qwerty"});
            _unitOfWork.Save();
//          var users = uow.GetRepository<Customer>().GetAll().ToList();
            var rooms = _unitOfWork.GetRepository<Room>().GetAll().ToList();
            //var rooms2 = uow.GetRepository<Room>().GetAll(x=>x.Name == "Столовая", q=>q.OrderBy(d=>d.Id), includeProperties: "Users").ToList();
            return Ok(rooms);
        }

    }
}
