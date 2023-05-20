using ArtExchange.Application.Contracts.Repository;
using ArtExchange.Domain.Entities;

namespace ArtExchange.Application.Feautures.Persons.Commands.Add
{
    public class CreatePersonCommandValidator : PersonValidator<CreatePersonCommand>
    {
        public CreatePersonCommandValidator(IRepositoryAsync<Person> personRepository) : base(personRepository)
        {

        }
    }
}
