using ArtExchange.Application.Contracts.Repository;
using ArtExchange.Application.Exceptions;
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
        public async Task Handle(DeletePersonCommand request, CancellationToken cancellationToken)
        {
            var person = await _personRepository.GetByIdAsync(request.Id);
            if (person == null) throw  new NotFoundException("Person with Id", request.Id);
            await _personRepository.DeleteAsync(person);
        }
    }
}
