using ArtExchange.Application.Contracts.Authentication;
using ArtExchange.Domain.Entities.Administration;

namespace ArtExchange.Application.Infrastructure.Security
{
    public class JwtProvider : IJwtProvider
    {
        public string Generate(Person person)
        {
            throw new NotImplementedException();
        }
    }
}
