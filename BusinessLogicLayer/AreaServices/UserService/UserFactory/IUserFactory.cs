using System.Collections.Generic;
using BusinessLogicLayer.Domains;

namespace BusinessLogicLayer.AreaServices.UserService.UserFactory
{
    /// <summary>
    /// Интерфейс IUserFactory
    /// Бизнес логика с сущностью User
    /// </summary>
    public interface IUserFactory
    {
        List<AppUser> OrderingUsers(List<AppUser> users);
    }
}