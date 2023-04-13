using FluentValidation;

namespace ArtExchange.Application.Feautures.Persons.Commands.Add
{
    public class CreatePersonCommandValidator:AbstractValidator<CreatePersonCommand>
    {
        public CreatePersonCommandValidator()
        {
            RuleFor(command =>
                command.FirstName).NotEmpty()
                .MaximumLength(250)
                .WithErrorCode("Player first name must not be empty");

            RuleFor(command =>
                command.LastName).NotEmpty()
                .MaximumLength(250)
                .WithErrorCode("Player last name must not be empty");

            RuleFor(command =>
                command.DataOfBirth)
                .LessThanOrEqualTo(DateTime.Now)
                .WithErrorCode("Date of birth is incorrect");

            RuleFor(command =>
                command.Email).NotEmpty()
                .MaximumLength(250)
                .EmailAddress()
                .WithErrorCode("Incorrect email");

        }
    }
}
