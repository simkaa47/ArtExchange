using MediatR;

namespace ArtExchange.Application.Feautures.Persons.Commands.Login
{
    public class LoginCommand : IRequest<string>
    {
        public string? Login { get; set; }
        public string? Password { get; set; }
    }
}
