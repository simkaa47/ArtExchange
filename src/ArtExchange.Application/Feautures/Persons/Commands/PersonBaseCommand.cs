using MediatR;

namespace ArtExchange.Application.Feautures.Persons.Commands
{
    public class PersonBaseCommand : PersonDto, IRequest<long>
    {
    }
}
