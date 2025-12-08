using ArtExchange.Modules.ArtMeetings.Domain.Abstractions;

namespace ArtExchange.Modules.ArtMeetings.Domain.Meetings;

public sealed class Meeting:Entity
{
    public Guid Id { get; private set; }
    public string Name { get; private set; }
    public string Description { get; private set; }
    public DateTime Date { get; private set; }
    public TimeSpan? Time { get; private set; }
    public string Location { get; private set; }
    public MeetingStatus Status { get; private set; }
    public MeetingType Type { get; private set; }
    private Meeting() { }

    public static Meeting CreateMeeting(string name, string description, DateTime date, TimeSpan? time, string location,
        MeetingType type)
    {
        var meeting = new Meeting()
        {
            Id = Guid.NewGuid(),
            Name = name,
            Description = description,
            Date = date,
            Time = time,
            Location = location,
            Type = type,
            Status = MeetingStatus.Draft
        };
        meeting.AddDomainEvent(new MeetingAddedDomainEvent(meeting.Id));
        
        return meeting;
    }
}
