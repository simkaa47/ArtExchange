using ArtExchange.Modules.ArtMeetings.Application.Meetings;

namespace ArtExchange.Modules.ArtMeetings.Application.Abstractions.Data;

public interface IMeetingsQueryRepository
{
    Task<MeetingResponse?> GetByIdAsync(Guid id);
}
