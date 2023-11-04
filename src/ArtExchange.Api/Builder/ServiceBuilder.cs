using ArtExchange.Api.Middlewares;
using ArtExchange.Api.OptionsSetup;
using ArtExchange.Application;
using ArtExchange.DataAccess;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace ArtExchange.Api.Builder
{

    public static class ServiceBuilder
    {

        public static IServiceCollection GetServiceCollection(IServiceCollection services = null!, IConfiguration configuration = null!)
        {
            if (services is null) services = new ServiceCollection();
            if (configuration is null) configuration = GetConfiguration();
            ConfigureCommonServices(services, configuration);
            ConfigureSensitiveServices(services, configuration);

            return services;
        }

        public static IServiceCollection ConfigureCommonServices(IServiceCollection services = null!, IConfiguration configuration = null!)
        {
            if (services is null) services = new ServiceCollection();
            services.AddApplicationServices();
            services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            services.AddEndpointsApiExplorer();
            AddAuthentication(services);            
            services.AddSwaggerGen();
            services.AddTransient<ExceptionHandlingMiddleware>();
            return services;
        }

        public static IServiceCollection ConfigureSensitiveServices(IServiceCollection services = null!, IConfiguration configuration = null!)
        {
            if (services is null) services = new ServiceCollection();
            services.AddDataContext(configuration);
            return services;
        }


        public static IConfiguration GetConfiguration()
        {
            var configuration = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build();
            return configuration;
        }

        private static void AddAuthentication(IServiceCollection services = null!, IConfiguration configuration = null!)
        {
            if (services is null) services = new ServiceCollection();            
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer()
                .AddCookie(options =>
                {                   
                    options.ExpireTimeSpan = TimeSpan.FromMinutes(10);
                    options.Cookie.HttpOnly = true;                     
                });

            services.ConfigureOptions<JwtOptionsSetup>();
            services.ConfigureOptions<JwtBearerOptionsSetup>();
        }

        

        




    }
}
