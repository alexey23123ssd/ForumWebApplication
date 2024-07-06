using Application.Common.DTOs;
using Application.Interfaces.Repositiries;
using Infrastructure.Services;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace Infrastructure.Extensions
{
    public static  class ServiceCollectionsExtension
    {
        public static void AddInfrastructureLayer(this IServiceCollection services)
        {
            services.AddAutoMapper();
            services.AddServices();
        }

        private static void AddAutoMapper(this IServiceCollection services)
        {
            services.AddAutoMapper(Assembly.GetExecutingAssembly());
        }

        private static void AddServices(this IServiceCollection services)
        {
            services.AddTransient<IGenericRepository<UserDTO>,UserService>();
        }
    }
}
