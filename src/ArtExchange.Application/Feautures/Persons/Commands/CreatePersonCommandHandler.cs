using MediatR;

namespace ArtExchange.Application.Feautures.Persons.Commands
{
    public class CreatePersonCommandHandler : IRequestHandler<CreatePersonCommand, long>
    {
        public CreatePersonCommandHandler()
        {

        }

        public async Task<long> Handle(CreatePersonCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
