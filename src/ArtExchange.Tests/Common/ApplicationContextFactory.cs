using ArtExchange.DataAccess.DataContext;
using ArtExchange.Domain.Entities;

namespace ArtExchange.Tests.Common
{
    public class ApplicationContextFactory
    {
        public static long NotExistId = 8;


        public static void Destroy(ApplicationContext? context)
        {
            context?.Database.EnsureDeleted();
            context?.Dispose();
        }

        public static async Task DbInitAsync(ApplicationContext? context)
        {
            context?.Database.EnsureCreated();
            context?.Persons.AddRange(
                new Person
                {
                    Id = 1,
                    Email = "petr2009@yahoo.com",
                    DataOfBirth = new DateTime(1993, 7, 12),
                    FirstName = "Nikita",
                    LastName = "Petrov"
                },
                new Person
                {
                    Id = 2,
                    Email = "logonavt@gmail.com",
                    DataOfBirth = new DateTime(1986, 9, 24),
                    FirstName = "Artem",
                    LastName = "Loginov"
                },
                 new Person
                 {
                     Id = 3,
                     Email = "simkaa7@gmail.com",
                     DataOfBirth = new DateTime(1988, 9, 30),
                     FirstName = "Serafim",
                     LastName = "Prilezhaev"
                 }
                );
            await context.SaveChangesAsync();
        }
    }
}
