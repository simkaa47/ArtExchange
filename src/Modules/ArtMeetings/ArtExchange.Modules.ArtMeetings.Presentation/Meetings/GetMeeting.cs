using ArtExchange.Modules.ArtMeetings.Application.Meetings;
using ArtExchange.Modules.ArtMeetings.Application.Meetings.Queries;
using ArtExchange.Modules.ArtMeetings.Application.Meetings.Queries.GetMeeting;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;

namespace ArtExchange.Modules.ArtMeetings.Presentation.Meetings;

internal static class GetMeeting
{
    public static void MapEndpoint(IEndpointRouteBuilder app)
    {
        app.MapGet("/meetings/{id}", async (Guid id, ISender sender) =>
        {
            MeetingResponse? response = await sender.Send(new GetMeetingQuery(id));
            
            return response == null ? Results.NotFound() : Results.Ok(response);
        }).WithTags(Tags.Meetings);
    }
}
