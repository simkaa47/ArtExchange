using ArtExchange.Modules.ArtMeetings.Domain.Abstractions;

namespace ArtExchange.Modules.ArtMeetings.Domain.Meetings;

public sealed class MeetingAddedDomainEvent(Guid meetingId) : DomainEvent
{
    public Guid MeetingId => meetingId;
}
