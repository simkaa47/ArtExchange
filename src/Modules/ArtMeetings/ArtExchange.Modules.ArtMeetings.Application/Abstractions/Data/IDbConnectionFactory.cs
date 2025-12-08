using System.Data;
using System.Data.Common;

namespace ArtExchange.Modules.ArtMeetings.Application.Abstractions.Data;

public interface IDbConnectionFactory
{
    ValueTask<DbConnection> CreateConnectionAsync();
}
