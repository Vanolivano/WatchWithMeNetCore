using System.Collections.Generic;
using System.Linq;
using BusinessLogicLayer.Domains;

namespace BusinessLogicLayer.AreaServices.UserService.UserFactory.Impl
{
    /// <summary>
    /// Класс UserFactory
    /// Реализует интерфейс IUserFactory
    /// </summary>
    public class UserFactory: IUserFactory
    {
        public List<User> GetUsers(List<User> users)
        {
            return users.OrderBy(o=>o.Id).ToList();
        }
    }
}