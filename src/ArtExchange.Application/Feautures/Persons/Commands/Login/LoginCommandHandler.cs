using ArtExchange.Application.Contracts.Repository;
using ArtExchange.Application.Exceptions;
using ArtExchange.Domain.Entities.Administration;
using MediatR;
using System.Net;

namespace ArtExchange.Application.Feautures.Persons.Commands.Login
{
    public class LoginCommandHandler : IRequestHandler<LoginCommand>
    {
        private readonly IRepositoryAsync<Person> _personRepository;

        public LoginCommandHandler(IRepositoryAsync<Person> personRepository)
        {
            _personRepository = personRepository;
        }
        public async Task Handle(LoginCommand request, CancellationToken cancellationToken)
        {
            var person = _personRepository.GetFirstWhere(p => p.Login == request.Login && p.Password == request.Password);
            if (person == null)
            {
                throw new RestException("Login or password is invalid", HttpStatusCode.Unauthorized);
            }
        }
    }
}
