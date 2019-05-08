using System.Collections.Generic;
using BusinessLogicLayer.Domains;

namespace BusinessLogicLayer.AreaServices.UserService
{
    /// <summary>
    /// Интерфейс IUserAreaService, работает с сущность User.
    /// Хранит методы для взаимодействия с IUserRepository/IUnitOFWork.
    /// Не содержит  бизнесс логики, для реализации бизнес логики
    /// используйте IUserFactory.
    /// </summary>
    public interface IUserAreaService
    {
        List<AppUser> GetUsers();
    }
}