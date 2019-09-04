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
        public List<AppUser> OrderingUsers(List<AppUser> users)
        {
            return users.OrderBy(o=>o.FacebookId).ToList();
        }
    }
}