using ArtExchange.Application.Contracts.Entity;

namespace ArtExchange.Domain.Entities
{
    public class Address:EntityCommon, IEntity
    {
        public string Name { get; set; } = string.Empty;
        public double Longitude { get; set; }
        public double Latitude { get; set; }
    }
}
