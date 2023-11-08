using ArtExchange.Domain.Entities.Administration;

namespace ArtExchange.Application.Feautures.Persons.Queries
{
    public class PersonVm
    {       
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string ImageUri { get; set; } = string.Empty;
        public DateTime DataOfBirth { get; set; }
        public string Login { get; set; } = string.Empty;       
        public Roles Role { get; set; }
    }
}
