namespace ArtExchange.Domain.Entities.Common
{
    public class Link:EntityCommon
    {
        public string Url { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
    }
}
