using ArtExchange.Application.Contracts.Repository;
using ArtExchange.Application.Contracts.Security;
using ArtExchange.Application.Exceptions;
using ArtExchange.Domain.Entities.Administration;
using MediatR;
using Microsoft.AspNetCore.Http;
using System.Net;

namespace ArtExchange.Application.Feautures.Persons.Commands.Login
{
    public class LoginCommandHandler : IRequestHandler<LoginCommand>
    {
        private readonly IRepositoryAsync<Person> _personRepository;
        private readonly IJwtProvider _jwtProvider;
        private readonly IPasswordHasher _passwordHasher;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public LoginCommandHandler(IRepositoryAsync<Person> personRepository,
            IJwtProvider jwtProvider, 
            IPasswordHasher passwordHasher, IHttpContextAccessor httpContextAccessor)
        {
            _personRepository = personRepository;
            _jwtProvider = jwtProvider;
            _passwordHasher = passwordHasher;
            _httpContextAccessor = httpContextAccessor;
        }
        public async Task Handle(LoginCommand request, CancellationToken cancellationToken)
        {
            var person = await _personRepository.GetFirstWhere(p => p.Login == request.Login);
            if (person == null || !(_passwordHasher.Verify(person.Password, request.Password)))
            {
                throw new RestException("Login or password is invalid", HttpStatusCode.Unauthorized);
            }
            if (_httpContextAccessor is null || _httpContextAccessor.HttpContext is null)
            {
                throw new Exception("Internal server error");
            }
            string token = _jwtProvider.Generate(person);
            _httpContextAccessor.HttpContext.Response.Cookies.Append("jwt", token);
        }
    }
}
