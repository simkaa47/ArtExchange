using ArtExchange.Modules.ArtMeetings.Domain.Meetings;

namespace ArtExchange.Modules.ArtMeetings.Infrastructure.DataAccess;

internal sealed class MeetingsRepository(MeetingsDbContext context):IMeetingsRepository
{
    public Task<Meeting?> GetByIdAsync(Guid id)
    {
        throw new NotImplementedException();
    }

    public async Task AddAsync(Meeting meeting)
    {
        await context.Meetings.AddAsync(meeting);
    }
}
