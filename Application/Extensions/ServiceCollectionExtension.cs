using Microsoft.Extensions.DependencyInjection;
using System.Reflection;
using MediatR;  
using FluentValidation;
using Application.Features.Users.ValidatorBehaviors;


namespace Application.Extensions
{
    public static class ServiceCollectionExtension
    {
        public static void AddApplicationLayer(this IServiceCollection services)
        {
            services.AddAutoMapper();
            services.AddMediator();
            services.AddValidators();
        }

        private static void AddAutoMapper(this IServiceCollection services)
        {
            services.AddAutoMapper(Assembly.GetExecutingAssembly());
        }

        private static void AddMediator(this IServiceCollection services)
        {
            services.AddMediatR(Assembly.GetExecutingAssembly());
        }

        private static void AddValidators(this IServiceCollection services)
        {
            services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly()); 
        }
    }
}
