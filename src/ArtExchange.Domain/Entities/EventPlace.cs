using ArtExchange.Application.Contracts.Entity;

namespace ArtExchange.Domain.Entities
{
    public class EventPlace:EntityCommon,IEntity
    {
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public Address? Address { get; set; }
    }
}
