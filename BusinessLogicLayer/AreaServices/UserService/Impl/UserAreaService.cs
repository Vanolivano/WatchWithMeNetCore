using System;
using System.Collections.Generic;
using System.Linq;
using BusinessLogicLayer.AreaServices.UserService.UserFactory;
using BusinessLogicLayer.Domains;
using DataAccessLayer.UnitOfWork;

namespace BusinessLogicLayer.AreaServices.UserService.Impl
{
    /// <summary>
    /// Класс UserAreaService, реализует интерфейс IUserAreaService.
    /// </summary>
    public class UserAreaService: IUserAreaService
    {
        private readonly IUnitOfWork _uow;
        private readonly IUserFactory _userFactory;

        public UserAreaService(IUnitOfWork unitOfWork, IUserFactory userFactory)
        {
            _uow = unitOfWork;
            _userFactory = userFactory;
        }
        public List<AppUser> GetUsers()
        {
            //берет пользователей из базы
            try
            {
                List<AppUser> users = _uow.GetRepository<AppUser>().GetAll().ToList();
                return _userFactory.GetUsers(users);
            }
            finally
            {
                _uow.Dispose();
            }
            //отправляет на обработку в userFactory для какой либо бизнесс-логики если это нужно

        }
    }
}
