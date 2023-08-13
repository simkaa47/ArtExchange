using ArtExchange.Domain.Entities.Common;

namespace ArtExchange.Domain.Entities.Events
{
    public class EventPlace : EntityCommon
    {
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public Address? Address { get; set; }
    }
}
