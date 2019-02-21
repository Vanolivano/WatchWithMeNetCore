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
        public List<User> GetUsers()
        {
            var users = _unitOfWork.GetRepository<User>().GetAll().ToList();
            return _userFactory.GetUsers(users);
        }
    }
}