using ArtExchange.Modules.ArtMeetings.Domain.Meetings;

namespace ArtExchange.Modules.ArtMeetings.Domain.Abstractions;

public abstract class Entity
{
    private readonly List<IDomainEvent> _domainEvents = [];
    protected Entity() { }
    public void ClearDomainEvents() => _domainEvents.Clear();
    public IReadOnlyCollection<IDomainEvent> GetDomainEvents() => _domainEvents.AsReadOnly();
    public void AddDomainEvent(IDomainEvent domainEvent) => _domainEvents.Add(domainEvent);
}
