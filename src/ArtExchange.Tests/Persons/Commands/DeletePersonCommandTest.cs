using ArtExchange.Application.Contracts.Repository;
using ArtExchange.Application.Exceptions;
using ArtExchange.Application.Feautures.Persons.Commands.Delete;
using ArtExchange.Domain.Entities;
using ArtExchange.Tests.Common;
using Shouldly;

namespace ArtExchange.Tests.Persons.Commands
{
    public class DeletePersonCommandTest : IClassFixture<TestCommandBase>
    {
        private readonly IRepositoryAsync<Person>? _personRepository = null;
        public DeletePersonCommandTest(TestCommandBase commonFixture)
        {
            _personRepository = commonFixture._personRepository;
        }

        [Fact]
        public async Task Should_throw_exception_if_id_not_exist()
        {
            //Arrange
            var command = new DeletePersonCommand { Id = ApplicationContextFactory.NotExistId};
            var handler = new DeletePersonCommandHandler(_personRepository);

            //Act
            //Assert
            await Should.ThrowAsync(async () =>
            {
                await handler.Handle(command, CancellationToken.None);
            }, typeof(NotFoundException));
        }
    }
}
