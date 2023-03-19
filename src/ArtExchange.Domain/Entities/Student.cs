using ArtExchange.Application.Contracts.Entity;

namespace ArtExchange.Domain.Entities
{
    public class Student:EntityCommon,IEntity
    {
        public Person? Person { get; set; }
        public List<Event> Events { get; set; } = new();
    }
}
