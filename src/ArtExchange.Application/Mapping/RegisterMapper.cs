using ArtExchange.Application.Feautures.Persons.Commands.Add;
using ArtExchange.Domain.Entities;
using Mapster;

namespace ArtExchange.Application.Mapping
{
    public class RegisterMapper : IRegister
    {
        public void Register(TypeAdapterConfig config)
        {
            config.NewConfig<Person, CreatePersonCommand>().RequireDestinationMemberSource(value: true);
        }
    }
}
