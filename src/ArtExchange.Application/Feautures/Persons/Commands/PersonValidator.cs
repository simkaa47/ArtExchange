using ArtExchange.Application.Contracts.Repository;
using ArtExchange.Domain.Entities.Administration;
using FluentValidation;

namespace ArtExchange.Application.Feautures.Persons.Commands
{
    public class PersonValidator<T> : AbstractValidator<T> where T : PersonDto
    {
        private readonly IRepositoryAsync<Person> _personRepository;

        private const int _minPasswordLength = 8;

        public PersonValidator(IRepositoryAsync<Person> personRepository)
        {
            RuleFor(command =>
                command.FirstName).NotEmpty()
                .MaximumLength(250)
                .WithMessage("Player first name must not be empty");

            RuleFor(command =>
                command.LastName).NotEmpty()
                .MaximumLength(250)
                .WithMessage("Player last name must not be empty");

            RuleFor(command =>
                command.DataOfBirth)
                .LessThanOrEqualTo(DateTime.Now)
                .WithMessage("Date of birth is incorrect");

            RuleFor(command =>
                command.Email).NotEmpty()
                .MaximumLength(250)
                .EmailAddress()
                .WithMessage("Incorrect email");

            RuleFor(command =>
                command.Email).Must(IsEmailUnique)
                .WithMessage(command => $"Email {command.Email} already belongs to other person");

            RuleFor(command =>
                command.Login).Must(IsLoginUnique)
                .WithMessage(command => $"Login must be unique");

            RuleFor(command => command.Login).NotEmpty()
                .WithMessage("Login should not be empty");

            RuleFor(command =>
                command.Password).MinimumLength(_minPasswordLength)
                .WithMessage(command => $"Password length must be more or equal then {_minPasswordLength}");  

            _personRepository = personRepository;
        }

        public bool IsEmailUnique(string email)
        {
            var result = _personRepository.GetFirstWhere(p => p.Email == email);
            return result.Result == null;
        }

        public bool IsLoginUnique(string login)
        {
            var result = _personRepository.GetFirstWhere(p => p.Login == login);
            return result.Result == null;
        }
    }
}
