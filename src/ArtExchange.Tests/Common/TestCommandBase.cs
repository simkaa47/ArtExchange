using ArtExchange.Api.Builder;
using ArtExchange.Application.Contracts.Repository;
using ArtExchange.DataAccess.DataContext;
using ArtExchange.DataAccess.Repositories;
using ArtExchange.Domain.Entities;
using MapsterMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace ArtExchange.Tests.Common
{
    public class TestCommandBase : IDisposable
    {
        public readonly IServiceProvider _serviceProvider;
        private readonly ApplicationContext? _context;
        public readonly IRepositoryAsync<Person> _personRepository;
        public readonly IMapper  _mapper;
        public TestCommandBase()
        {
            var services = ServiceBuilder.ConfigureCommonServices();
            services.AddDbContext<ApplicationContext>(options =>
            {
                options.UseInMemoryDatabase("ArtExchangeFakeDatabase");

            });
            services.AddScoped(typeof(IRepositoryAsync<>), typeof(BaseRepository<>));
            _serviceProvider = services.BuildServiceProvider();
            _context = _serviceProvider.GetRequiredService<ApplicationContext>();
            _personRepository = _serviceProvider.GetRequiredService<IRepositoryAsync<Person>>();
            _mapper = _serviceProvider.GetRequiredService<IMapper>();   
            InitDbAsync();

        }


        public async void InitDbAsync()
        {
            await ApplicationContextFactory.DbInitAsync(_context);            
        }

        public void Dispose()
        {
            ApplicationContextFactory.Destroy(_context);
        }
    }
}
