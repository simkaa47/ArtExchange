using ArtExchange.Modules.ArtMeetings.Domain.Meetings;

namespace ArtExchange.Modules.ArtMeetings.Domain.Abstractions;

public abstract class DomainEvent(Guid id, DateTime occurredAtUtc) : IDomainEvent
{
    protected DomainEvent() : this(Guid.NewGuid(), DateTime.UtcNow)
    {
    }

    public Guid Id { get; } = id;
    public DateTime OccurredAtUtc { get; } = occurredAtUtc;
}
