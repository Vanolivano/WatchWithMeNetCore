﻿using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using BusinessLogicLayer.Domains;
using BusinessLogicLayer.EF;
using BusinessLogicLayer.ViewModels;
using DataAccessLayer.UnitOfWork;
using Microsoft.AspNetCore.Mvc;

namespace BusinessLogicLayer.Controllers
{

    public class HomeController : Controller
    {
        private readonly DatabaseContext _context;
        private readonly IUnitOfWork _unitOfWork;
        public HomeController(DatabaseContext context, IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            _context = context;
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


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel {RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier});
        }
    }
}
