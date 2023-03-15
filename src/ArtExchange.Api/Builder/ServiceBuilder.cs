using ArtExchange.DataAccess;

namespace ArtExchange.Api.Builder
{

    public static class ServiceBuilder
    {

        public static IServiceCollection GetServiceCollection(IServiceCollection services = null!, IConfiguration configuration = null!)
        {
            if (services is null) services = new ServiceCollection();
            if (configuration is null) configuration = GetConfiguration();
            services.AddDataContext(configuration);

            services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen();

            return services;
        }


        public static IConfiguration GetConfiguration()
        {
            var configuration = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build();
            return configuration;
        }
    }
}
