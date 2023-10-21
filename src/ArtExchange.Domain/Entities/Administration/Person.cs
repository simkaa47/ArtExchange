using ArtExchange.Domain.Entities.Common;

namespace ArtExchange.Domain.Entities.Administration
{
    public class Person : EntityCommon
    {
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string ImageUri { get; set; } = string.Empty;
        public DateTime DataOfBirth { get; set; }
        public string Login { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
    }
}
