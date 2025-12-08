using ArtExchange.Modules.ArtMeetings.Infrastructure.DataAccess;
using Microsoft.EntityFrameworkCore;

namespace ArtExchange.API.Extensions;

internal static class MigrationExtensions
{
    internal static void MigrateDatabases(this IApplicationBuilder builder)
    {
        using IServiceScope scope = builder.ApplicationServices.CreateScope();
        Migrate<MeetingsDbContext>(scope);
    }

    private static void Migrate<T>(IServiceScope scope) where T : DbContext
    {
        using T context = scope.ServiceProvider.GetRequiredService<T>();
        context.Database.Migrate();
    }
}
