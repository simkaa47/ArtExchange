namespace ArtExchange.Modules.ArtMeetings.Domain.Meetings;

public interface IMeetingsRepository
{
    Task<Meeting?> GetByIdAsync(Guid id);
    Task AddAsync(Meeting meeting);
}
