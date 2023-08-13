using ArtExchange.Domain.Entities.Common;

namespace ArtExchange.Domain.Entities.Events
{
    public class Address : EntityCommon
    {
        public string Name { get; set; } = string.Empty;
        public double Longitude { get; set; }
        public double Latitude { get; set; }
    }
}
