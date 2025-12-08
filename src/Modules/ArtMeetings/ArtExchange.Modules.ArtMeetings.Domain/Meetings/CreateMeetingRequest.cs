namespace ArtExchange.Modules.ArtMeetings.Domain.Meetings;

public sealed class CreateMeetingRequest
{
    public required string Name { get; set; }
    public required string Description { get; set; }
    public DateTime Date { get; set; }
    public TimeSpan? Time { get; set; }
    public required string Location { get; set; }
    public MeetingType Type { get; set; }
}
