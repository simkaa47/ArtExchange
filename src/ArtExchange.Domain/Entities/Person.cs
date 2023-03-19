using ArtExchange.Application.Contracts.Entity;

namespace ArtExchange.Domain.Entities
{
    public class Person: EntityCommon, IEntity
    {
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string ImageUri { get; set; } = string.Empty;
        public DateTime DataOfBirth { get; set; }
    }
}
