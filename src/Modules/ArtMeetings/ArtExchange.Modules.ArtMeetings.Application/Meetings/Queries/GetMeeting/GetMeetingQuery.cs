using MediatR;

namespace ArtExchange.Modules.ArtMeetings.Application.Meetings.Queries.GetMeeting;

public sealed record GetMeetingQuery(Guid Id): IRequest<MeetingResponse?>;
