namespace ArtExchange.Domain.Entities
{
    public class Address:EntityCommon
    {
        public string Name { get; set; } = string.Empty;
        public double Longitude { get; set; }
        public double Latitude { get; set; }
    }
}
