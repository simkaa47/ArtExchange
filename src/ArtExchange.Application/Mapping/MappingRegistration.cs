
using Mapster;
using MapsterMapper;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace ArtExchange.Application.Mapping
{
    internal static class MappingRegistration
    {
        public static IServiceCollection AddMapper(this IServiceCollection services)
        {

            var config = TypeAdapterConfig.GlobalSettings;
            config.Scan(Assembly.GetExecutingAssembly());


            services.AddSingleton(config);
            services.AddScoped<IMapper, ServiceMapper>();
            return services;
        }

       
    }
}
