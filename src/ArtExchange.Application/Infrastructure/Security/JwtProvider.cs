using ArtExchange.Application.Contracts.Security;
using ArtExchange.Domain.Entities.Administration;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace ArtExchange.Application.Infrastructure.Security
{
    public class JwtProvider : IJwtProvider
    {
        private readonly JwtOptions _options;

        public JwtProvider(IOptions<JwtOptions> options)
        {
            _options = options.Value;
        }
        public string Generate(Person person)
        {
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, person.Login),
                new Claim(ClaimTypes.Role, person.Role.ToString())
            };

            var credentials = new SigningCredentials(
                new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_options.SecretKey)),
                SecurityAlgorithms.HmacSha512Signature);

            var token = new JwtSecurityToken(
                _options.Issuer,
                _options.Audience,
                claims,
                null,
                DateTime.UtcNow.AddHours(12),
                credentials);

            var tokenValue = new JwtSecurityTokenHandler().WriteToken(token);
            return tokenValue;

        }


    }
}
