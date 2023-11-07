using ArtExchange.Application.Contracts.Authentication;
using ArtExchange.Application.Contracts.Repository;
using ArtExchange.Application.Exceptions;
using ArtExchange.Domain.Entities.Administration;
using MediatR;
using Microsoft.AspNetCore.Http;
using System.Net;

namespace ArtExchange.Application.Feautures.Persons.Commands.Login
{
    public class LoginCommandHandler : IRequestHandler<LoginCommand,string>
    {
        private readonly IRepositoryAsync<Person> _personRepository;
        private readonly IJwtProvider _jwtProvider;

        public LoginCommandHandler(IRepositoryAsync<Person> personRepository, IJwtProvider jwtProvider)
        {
            _personRepository = personRepository;
            _jwtProvider = jwtProvider;
        }
        public async Task<string> Handle(LoginCommand request, CancellationToken cancellationToken)
        {
            var person = await _personRepository.GetFirstWhere(p => p.Login == request.Login && p.Password == request.Password);
            if (person == null)
            {
                throw new RestException("Login or password is invalid", HttpStatusCode.Unauthorized);
            }
            string token = _jwtProvider.Generate(person);
            return token;
        }
    }
}
