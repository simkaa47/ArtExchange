using Microsoft.AspNetCore.Routing;

namespace ArtExchange.Modules.ArtMeetings.Presentation.Meetings;

public static class MeetingsEndpoints
{
    public static void MapMeetingsEndpoints(IEndpointRouteBuilder app)
    {
        AddMeeting.MapEndpoint(app);
        GetMeeting.MapEndpoint(app);
    }
}
