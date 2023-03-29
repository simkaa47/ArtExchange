namespace ArtExchange.Domain.Entities
{
    public class EventPlace:EntityCommon
    {
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public Address? Address { get; set; }
    }
}
