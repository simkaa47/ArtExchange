using ArtExchange.Domain.Entities.Administration;
using ArtExchange.Domain.Entities.Common;
using ArtExchange.Domain.Entities.Events;
using Microsoft.EntityFrameworkCore;

namespace ArtExchange.DataAccess.DataContext
{
    public class ApplicationContext:DbContext
    {
        public DbSet<Person> Persons { get; set; } = null!;
        public DbSet<Event> Events { get; set; } = null!;
        public DbSet<EventPlace> EventsPlaces { get; set; } = null!;
        public DbSet<Address> Addresses { get; set; } = null!;
        public DbSet<Teacher> Teachers { get; set; } = null!;
        public DbSet<Student> Students { get; set; } = null!;

        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options)
        {
            AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApplicationContext).Assembly);
            base.OnModelCreating(modelBuilder);
        }

        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            foreach (var entry in ChangeTracker.Entries<EntityCommon>())
            {
                switch (entry.State)
                {
                    case EntityState.Modified:
                        entry.Entity.LastModifiedDate = DateTime.Now;
                        break;
                    case EntityState.Added:
                        entry.Entity.CreatedDate = DateTime.Now;
                        break;
                }
            }
            return await base.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
        }
    }
}
