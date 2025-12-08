using ArtExchange.Modules.ArtMeetings.Application.Abstractions.Data;
using MediatR;

namespace ArtExchange.Modules.ArtMeetings.Application.Meetings.Queries.GetMeeting;

internal sealed class GetMeetingQueryHandler(IMeetingsQueryRepository meetingsQueryRepository):IRequestHandler<GetMeetingQuery, MeetingResponse?>
{
    public async Task<MeetingResponse?> Handle(GetMeetingQuery request, CancellationToken cancellationToken)
    {
        return await meetingsQueryRepository.GetByIdAsync(request.Id);
    }
}
