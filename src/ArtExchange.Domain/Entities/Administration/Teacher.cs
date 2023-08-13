using ArtExchange.Domain.Entities.Common;
using ArtExchange.Domain.Entities.Events;

namespace ArtExchange.Domain.Entities.Administration
{
    public class Teacher : EntityCommon
    {
        public Person? Person { get; set; }
        public List<Event> Events { get; set; } = new();
        public List<ArtClassType> ArtPrefrences { get; set; } = new();
        public string Description { get; set; } = string.Empty;
        public List<Link> Links { get; set; } = new();

    }
}
