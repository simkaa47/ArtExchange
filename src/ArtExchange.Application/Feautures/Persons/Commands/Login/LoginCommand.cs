using MediatR;

namespace ArtExchange.Application.Feautures.Persons.Commands.Login
{
    public class LoginCommand : IRequest
    {
        public string? Email { get; set; }
        public string? Password { get; set; }
    }
}
