using MediatR;

namespace ArtExchange.Application.Feautures.Persons.Commands.Add;

public class CreatePersonCommand : PersonDto, IRequest<long>
{        
}
