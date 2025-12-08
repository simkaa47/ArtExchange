using ArtExchange.Modules.ArtMeetings.Application.Abstractions.Data;
using ArtExchange.Modules.ArtMeetings.Domain.Meetings;
using MediatR;

namespace ArtExchange.Modules.ArtMeetings.Application.Meetings.Commands.AddMeeting;

internal sealed class AddMeetingCommandHandler(IMeetingsRepository meetingsRepository, IUnitOfWork unitOfWork)
    : IRequestHandler<AddMeetingCommand, Guid>
{
    public async Task<Guid> Handle(AddMeetingCommand request, CancellationToken cancellationToken)
    {
        var meeting = Meeting.CreateMeeting(request.Name, request.Description, request.Date, request.Time,
            request.Location, request.Type);

        await meetingsRepository.AddAsync(meeting);
        await unitOfWork.SaveChangesAsync(cancellationToken);

        return meeting.Id;
    }
}
