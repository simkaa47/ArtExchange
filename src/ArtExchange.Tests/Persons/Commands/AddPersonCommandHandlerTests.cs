using ArtExchange.Application.Feautures.Persons.Commands.Add;
using ArtExchange.Application.Pipelines;
using ArtExchange.Tests.Common;
using DiffEngine;
using FluentValidation;
using Shouldly;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;


namespace ArtExchange.Tests.Persons.Commands
{
    public class AddPersonCommandHandlerTests : TestCommandBase
    {
        private readonly CreatePersonCommandHandler _handler;
        private readonly ValidationBehavior<CreatePersonCommand, long> _validationBehavior;

        private readonly CreatePersonCommand _command;

        public AddPersonCommandHandlerTests()
        {
            _handler = new CreatePersonCommandHandler(_personRepository, _mapper);
            _validationBehavior = new ValidationBehavior<CreatePersonCommand, long>(new List<CreatePersonCommandValidator>()
            {
                new CreatePersonCommandValidator(_personRepository)
            });
            _command = new CreatePersonCommand
            {
                LastName = "Segal",
                FirstName = "Stiven",
                DataOfBirth = DateTime.Now.AddYears(-20),
                Email = "superstiven@gmail.com",
                Password = "password",
                Login = "SuperStiven"

            };
        }        

        [Fact]
        public async Task AddPersonCommandHandler_Success()
        {
            //Arrange            

            //Act
            var result = await _validationBehavior.Handle(_command, async () => await _handler.Handle(_command, CancellationToken.None), CancellationToken.None);

            //Assert
            Assert.True(result > 0);
        }

        [Theory]
        [InlineData("hello")]
        [InlineData("petr2009@yahoo.com")]
        public async Task Should_not_create_person_if_incorrect_email(string email)
        {
            //Arrange
            _command.Email = email;

            //Act
            //Assert 
            await Should.ThrowAsync(async () =>
            {
                var result = await _validationBehavior.Handle(_command, async () => await _handler.Handle(_command, CancellationToken.None), CancellationToken.None);
            }, typeof(ValidationException)); 

        }

        [Theory]
        [InlineData("", "")]
        [InlineData("", "Jackson")]
        [InlineData("Michael", "")]
        public async Task Should_not_create_person_if_incorrect_first_or_lastname(string firstName, string lastName)
        {
            //Arrange
            _command.FirstName = firstName;
            _command.LastName = lastName;

            //Act
            //Assert 
            await Should.ThrowAsync(async () =>
            {
                var result = await _validationBehavior.Handle(_command, async () => await _handler.Handle(_command, CancellationToken.None), CancellationToken.None);
            }, typeof(ValidationException), "Incorrect first or last names");

        }
        [Theory]
        [InlineData("")]
        [InlineData("nik2009")]
        public async Task Should_not_create_person_if_incorrect_login(string login)
        {

            _command.Login = login;
            await Should.ThrowAsync(async () =>
            {
                var result = await _validationBehavior.Handle(_command, async () => await _handler.Handle(_command, CancellationToken.None), CancellationToken.None);
            }, typeof(ValidationException), $"Incorrect login {login}");

        }
        [Theory]
        [InlineData("")]
        public async Task Should_not_create_person_if_incorrect_password(string password)
        {
            _command.Password = password;
            await Should.ThrowAsync(async () =>
            {
                var result = await _validationBehavior.Handle(_command, async () => await _handler.Handle(_command, CancellationToken.None), CancellationToken.None);
            }, typeof(ValidationException), $"Incorrect password {password}");
        }







    }
}
