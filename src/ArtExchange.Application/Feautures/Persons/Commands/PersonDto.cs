﻿namespace ArtExchange.Application.Feautures.Persons.Commands
{
    public class PersonDto
    {
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string ImageUri { get; set; } = string.Empty;
        public DateTime DataOfBirth { get; set; } = DateTime.Today.AddYears(-20);

    }
}
