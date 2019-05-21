using BusinessLogicLayer.AreaServices.UserService;
using BusinessLogicLayer.AreaServices.UserService.Impl;
using BusinessLogicLayer.AreaServices.UserService.UserFactory;
using BusinessLogicLayer.AreaServices.UserService.UserFactory.Impl;
using Microsoft.Extensions.DependencyInjection;

namespace BusinessLogicLayer.Extensions
{
    public static class UserServiceCollectionExtensions
    {
        public static IServiceCollection AddUser(this IServiceCollection services)
        {
            services.AddScoped<IUserFactory, UserFactory>();
            services.AddScoped<IUserAreaService, UserAreaService>();
            return services;
        }
    }
}
