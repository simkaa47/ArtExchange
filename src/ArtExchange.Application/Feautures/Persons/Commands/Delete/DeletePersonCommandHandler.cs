using ArtExchange.Application.Contracts.Repository;
using ArtExchange.Domain.Entities;
using MediatR;

namespace ArtExchange.Application.Feautures.Persons.Commands.Delete
{
    public class DeletePersonCommandHandler : IRequestHandler<DeletePersonCommand>
    {
        private readonly IRepositoryAsync<Person> _personRepository;

        public DeletePersonCommandHandler(IRepositoryAsync<Person> personRepository)
        {
            _personRepository = personRepository;
        }
        public Task Handle(DeletePersonCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
