using ArtExchange.Modules.ArtMeetings.Domain.Meetings;
using FluentValidation;
using MediatR;

namespace ArtExchange.Modules.ArtMeetings.Application.Meetings.Commands.AddMeeting;

public sealed record AddMeetingCommand(
    string Name,
    string Description,
    string Location,
    MeetingType Type,
    DateTime Date,
    TimeSpan? Time) : IRequest<Guid>;


internal sealed class AddMeetingCommandValidator : AbstractValidator<AddMeetingCommand>
{
    public AddMeetingCommandValidator()
    {
        RuleFor(m=>m.Name).NotEmpty();
        RuleFor(m=>m.Description).NotEmpty();
        RuleFor(m=>m.Location).NotEmpty();
        RuleFor(m=>m.Date).GreaterThan(DateTime.UtcNow);
        RuleFor(m=>m.Time).NotNull();
    }
}
