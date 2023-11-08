namespace ArtExchange.Application.Contracts.Security
{
    public interface IPasswordHasher
    {
        bool Verify(string? passwordHash, string? inputPassword);
        string GetHash(string password);
    }
}
