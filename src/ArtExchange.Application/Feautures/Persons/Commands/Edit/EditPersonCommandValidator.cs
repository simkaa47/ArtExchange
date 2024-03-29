﻿using ArtExchange.Application.Contracts.Repository;
using ArtExchange.Domain.Entities.Administration;

namespace ArtExchange.Application.Feautures.Persons.Commands.Edit
{
    public class EditPersonCommandValidator : PersonValidator<EditPersonCommand>
    {
        public EditPersonCommandValidator(IRepositoryAsync<Person> personRepository) : base(personRepository)
        {
        }
    }
}
