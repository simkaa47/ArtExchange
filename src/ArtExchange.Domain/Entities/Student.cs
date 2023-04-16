namespace ArtExchange.Domain.Entities
{
    public class Student:EntityCommon
    {
        public Person? Person { get; set; }
        public List<Event> Events { get; set; } = new();
    }
}
