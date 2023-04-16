namespace ArtExchange.Domain.Entities
{
    public class Event : EntityCommon
    {
        public string Name { get; set; } = string.Empty;

        public DateTime StartTime { get; set; }

        public int MinAge { get; set; }
        public int MaxAge { get; set; }
        public int MaxStudentsCount { get; set; }
        public int MinStudenstsCount { get; set; }
        public TimeSpan Duration { get; set; }
        public string Note { get; set; } = string.Empty;
        public EventPlace? Place { get; set; }
        public List<Student> Students { get; set; } = new();
        public List<Teacher> Teachers { get; set; } = new();
    }
}
