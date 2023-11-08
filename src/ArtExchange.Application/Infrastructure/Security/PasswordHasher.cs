using ArtExchange.Application.Contracts.Security;
using System.Security.Cryptography;

namespace ArtExchange.Application.Infrastructure.Security
{
    public class PasswordHasher : IPasswordHasher
    {
        private const int SaltSize = 16;
        private const int KeySize = 32;
        private const int Iterations = 10000;
        private static readonly HashAlgorithmName _hashAlgorithmName = HashAlgorithmName.SHA256;
        private const string Separator = ":";

        public string GetHash(string password)
        {
            var salt = RandomNumberGenerator.GetBytes(SaltSize);
            var hash = Rfc2898DeriveBytes.Pbkdf2(password, salt, Iterations, _hashAlgorithmName, KeySize);
            var result = string.Join(Separator, Convert.ToBase64String(salt), Convert.ToBase64String(hash));
            return result;
        }

        public bool Verify(string? passwordHash, string? inputPassword)
        {
            if (string.IsNullOrEmpty(passwordHash) || string.IsNullOrEmpty(inputPassword)) return false;
            var parts = passwordHash.Split(Separator);
            if (parts.Length != 2) return false;
            var salt = Convert.FromBase64String(parts[0]);
            var hash = Convert.FromBase64String(parts[1]);

            var hashInput = Rfc2898DeriveBytes.Pbkdf2(inputPassword, salt, Iterations, _hashAlgorithmName, KeySize);
            return CryptographicOperations.FixedTimeEquals(hash, hashInput);    
        }
    }
}
