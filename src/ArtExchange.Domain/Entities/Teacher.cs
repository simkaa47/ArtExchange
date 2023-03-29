

namespace ArtExchange.Domain.Entities
{
    public class Teacher:EntityCommon
    {
        public Person? Person { get; set; }
        public List<Event> Events { get; set; } = new();

    }
}
