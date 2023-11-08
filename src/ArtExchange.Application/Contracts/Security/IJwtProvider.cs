using ArtExchange.Domain.Entities.Administration;

namespace ArtExchange.Application.Contracts.Security
{
    public interface IJwtProvider
    {
        string Generate(Person person);

    }
}
