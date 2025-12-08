using ArtExchange.Modules.ArtMeetings.Domain.Meetings;

namespace ArtExchange.Modules.ArtMeetings.Application.Meetings;

public record MeetingResponse(
    Guid Id,
    string Name,
    string Description,
    DateTime Date,
    TimeSpan? Time,
    string Location,
    MeetingStatus Status,
    MeetingType Type);
