using FluentValidation;

namespace ArtExchange.Application.Feautures.Persons.Commands.Login
{
    public class LoginCommandValidator: AbstractValidator<LoginCommand>
    {
        public LoginCommandValidator()
        {
            RuleFor(command => command.Password).NotEmpty()
                .WithMessage("Password must not be empty");

            RuleFor(command => command.Login).NotEmpty()
                .WithMessage("Login must not be empty");
        }
    }
}
