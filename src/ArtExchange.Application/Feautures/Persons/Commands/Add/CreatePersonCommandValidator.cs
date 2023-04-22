using ArtExchange.Application.Contracts.Repository;
using ArtExchange.Domain.Entities;
using FluentValidation;

namespace ArtExchange.Application.Feautures.Persons.Commands.Add
{
    public class CreatePersonCommandValidator:AbstractValidator<CreatePersonCommand>
    {
        private readonly IRepositoryAsync<Person> _personRepository;

        public CreatePersonCommandValidator(IRepositoryAsync<Person> personRepository)
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
                .WithMessage(command=>$"Email {command.Email} already belongs to other person");



            _personRepository = personRepository;
        }

        public bool IsEmailUnique(string email)
        {
            var result =  _personRepository.GetFirstWhere(p => p.Email == email);
            return result.Result == null;
        }
    }
}
