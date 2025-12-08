using System.Data.Common;
using Dapper;
using ArtExchange.Modules.ArtMeetings.Application.Abstractions.Data;
using ArtExchange.Modules.ArtMeetings.Application.Meetings;
using ArtExchange.Modules.ArtMeetings.Domain.Meetings;

namespace ArtExchange.Modules.ArtMeetings.Infrastructure.DataAccess.Data;

public class MeetingsQueryRepository(IDbConnectionFactory dbConnectionFactory):IMeetingsQueryRepository
{
    public async Task<MeetingResponse?> GetByIdAsync(Guid id)
    {
        await using DbConnection connection = await dbConnectionFactory.CreateConnectionAsync();
        const string commandText = $@"SELECT * FROM meetings.""Meetings"" WHERE ""Id"" = @{nameof(id)}";
        return await connection.QuerySingleOrDefaultAsync<MeetingResponse>(commandText, new {id});
    }
}
