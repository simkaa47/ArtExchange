using ArtExchange.Application.Contracts.Repository;
using ArtExchange.DataAccess.DataContext;
using ArtExchange.DataAccess.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace ArtExchange.DataAccess
{
    public static class DataContextRegistration
    {
        public static void AddDataContext(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<ApplicationContext>(options =>
            {
                options.UseNpgsql(configuration.GetConnectionString("Postgres"), b=>b.MigrationsAssembly("ArtExchange.Api"));
                
            });
            services.AddScoped(typeof(IRepositoryAsync<>), typeof(BaseRepository<>));
        }
    }
}
