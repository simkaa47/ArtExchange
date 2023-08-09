using ArtExchange.Application.Feautures.Persons.Commands.Add;
using ArtExchange.Application.Pipelines;
using ArtExchange.Tests.Common;
using FluentValidation;
using Shouldly;


namespace ArtExchange.Tests.Persons.Commands
{
    public class AddPersonCommandHandlerTests : TestCommandBase
    {
        private readonly CreatePersonCommandHandler _handler;
        private readonly ValidationBehavior<CreatePersonCommand, long> _validationBehavior;

        public AddPersonCommandHandlerTests()
        {
            _handler = new CreatePersonCommandHandler(_personRepository, _mapper);
            _validationBehavior = new ValidationBehavior<CreatePersonCommand, long>(new List<CreatePersonCommandValidator>()
            {
                new CreatePersonCommandValidator(_personRepository)
            });
        }        

        [Fact]
        public async Task AddPersonCommandHandler_Success()
        {
            //Arrange
            var command = new CreatePersonCommand
            {
                LastName = "Segal",
                FirstName = "Stiven",
                DataOfBirth = DateTime.Now.AddYears(-20),
                Email = "superstiven@gmail.com"
            };

            //Act
            var result = await _validationBehavior.Handle(command, async () => await _handler.Handle(command, CancellationToken.None), CancellationToken.None);

            //Assert
            Assert.True(result > 0);
        }

        [Theory]
        [InlineData("hello")]
        [InlineData("petr2009@yahoo.com")]
        public async Task Should_not_create_person_if_incorrect_email(string email)
        {
            //Arrange
            var command = new CreatePersonCommand
            {
                LastName = "Segal",
                FirstName = "Stiven",
                DataOfBirth = DateTime.Now.AddYears(-20),
                Email = email
            };

            //Act
            //Assert 
            await Should.ThrowAsync(async () =>
            {
                var result = await _validationBehavior.Handle(command, async () => await _handler.Handle(command, CancellationToken.None), CancellationToken.None);
            }, typeof(ValidationException)); 

        }

        [Theory]
        [InlineData("", "")]
        [InlineData("", "Jackson")]
        [InlineData("Michael", "")]
        public async Task Should_not_create_person_if_incorrect_first_or_lastname(string firstName, string lastName)
        {
            //Arrange
            var command = new CreatePersonCommand
            {
                LastName = firstName,
                FirstName = lastName,
                DataOfBirth = DateTime.Now.AddYears(-20),
                Email = "correct@mail.com"
            };

            //Act
            //Assert 
            await Should.ThrowAsync(async () =>
            {
                var result = await _validationBehavior.Handle(command, async () => await _handler.Handle(command, CancellationToken.None), CancellationToken.None);
            }, typeof(ValidationException), "Incorrect first or last names");

        }






    }
}
