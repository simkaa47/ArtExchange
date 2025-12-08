using System.Data.Common;
using ArtExchange.Modules.ArtMeetings.Application.Abstractions.Data;

namespace ArtExchange.Modules.ArtMeetings.Infrastructure.DataAccess;

public class DbConnectionFactory(DbDataSource dataSource):IDbConnectionFactory
{
    public async ValueTask<DbConnection> CreateConnectionAsync()
    {
        return await dataSource.OpenConnectionAsync();
    }
}
