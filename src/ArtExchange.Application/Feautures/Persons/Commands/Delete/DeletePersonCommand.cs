using MediatR;

namespace ArtExchange.Application.Feautures.Persons.Commands.Delete
{
    public class DeletePersonCommand:IRequest
    {
        public long Id { get; set; }
    }
}
