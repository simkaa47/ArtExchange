using MediatR;

namespace ArtExchange.Application.Feautures.Persons.Commands.Edit;

public class EditPersonCommand: PersonDto, IRequest
{
    public long Id { get; set; }
}
