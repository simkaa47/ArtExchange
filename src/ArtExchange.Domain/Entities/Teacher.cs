using ArtExchange.Application.Contracts.Entity;

namespace ArtExchange.Domain.Entities
{
    public class Teacher:EntityCommon, IEntity
    {
        public Person? Person { get; set; }
        public List<Event> Events { get; set; } = new();

    }
}
