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
        private readonly IUnitOfWork _unitOfWork;
        private readonly IUserFactory _userFactory;

        public UserAreaService(IUnitOfWork unitOfWork, IUserFactory userFactory)
        {
            _unitOfWork = unitOfWork;
            _userFactory = userFactory;
        }
        public List<AppUser> GetUsers()
        {
            //берет пользователей из базы
            var users = _unitOfWork.GetRepository<AppUser>().GetAll().ToList();
            //отправляет на сортировку в userFactory
            return _userFactory.OrderingUsers(users);
        }
    }
}
