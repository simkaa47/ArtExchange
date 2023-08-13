using ArtExchange.Domain.Entities.Common;
using ArtExchange.Domain.Entities.Events;

namespace ArtExchange.Domain.Entities.Administration
{
    public class Student : EntityCommon
    {
        public Person? Person { get; set; }
        public List<Event> Events { get; set; } = new();
    }
}
