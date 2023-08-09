using ArtExchange.Application.Exceptions;
using ArtExchange.Application.Feautures.Persons.Commands.Delete;
using ArtExchange.Tests.Common;
using Shouldly;

namespace ArtExchange.Tests.Persons.Commands
{
    public class DeletePersonCommandTest : TestCommandBase
    {

        [Fact]
        public async Task Should_throw_exception_if_id_not_exist()
        {
            //Arrange
            var command = new DeletePersonCommand { Id = ApplicationContextFactory.NotExistId };
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
