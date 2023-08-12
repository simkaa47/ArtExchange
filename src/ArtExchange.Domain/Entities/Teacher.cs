

using ArtExchange.Domain.Common;

namespace ArtExchange.Domain.Entities
{
    public class Teacher:EntityCommon
    {
        public Person? Person { get; set; }
        public List<Event> Events { get; set; } = new();
        public List<ArtClassType> ArtPrefrences { get; set; } = new();
        public string Description { get; set; } = string.Empty;
        public List<string> Links { get; set; } = new();

    }
}
