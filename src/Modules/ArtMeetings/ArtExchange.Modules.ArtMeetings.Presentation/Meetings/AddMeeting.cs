using ArtExchange.Modules.ArtMeetings.Application.Meetings;
using ArtExchange.Modules.ArtMeetings.Application.Meetings.Commands;
using ArtExchange.Modules.ArtMeetings.Application.Meetings.Commands.AddMeeting;
using ArtExchange.Modules.ArtMeetings.Domain.Meetings;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;

namespace ArtExchange.Modules.ArtMeetings.Presentation.Meetings;

internal static class AddMeeting
{
    public static void MapEndpoint(IEndpointRouteBuilder app)
    {
        app.MapPost("meetings", async (CreateMeetingRequest request, ISender sender) =>
        {
            var command = new AddMeetingCommand(request.Name, request.Description, request.Location, request.Type,
                request.Date, request.Time);

            Guid meetingId = await sender.Send(command);
            
            return Results.Ok(meetingId);
        }).WithTags(Tags.Meetings);
    }
}
