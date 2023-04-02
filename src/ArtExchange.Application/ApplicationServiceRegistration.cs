using ArtExchange.Application.Mapping;
using Mapster;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace ArtExchange.Application
{
    public static class ApplicationServiceRegistration
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));
            services.AddMapper();

            return services;
        }

        
    }
}
