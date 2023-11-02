using ArtExchange.Domain.Entities.Administration;

namespace ArtExchange.Application.Contracts.Authentication
{
    public interface IJwtProvider
    {
        string Generate(Person person);
    }
}
