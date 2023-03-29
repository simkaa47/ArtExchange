using ArtExchange.Application.Contracts.Repository;
using ArtExchange.Domain.Entities;
using MediatR;

namespace ArtExchange.Application.Feautures.Persons.Commands
{
    public class CreatePersonCommandHandler : IRequestHandler<CreatePersonCommand, long>
    {
        private readonly IRepositoryAsync<Person> _personRepository;

        public CreatePersonCommandHandler(IRepositoryAsync<Person> personRepository)
        {
            _personRepository = personRepository;
        }

        public async Task<long> Handle(CreatePersonCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
 