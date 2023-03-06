using ArtExchange.Application.Contracts.Entity;

namespace ArtExchange.Domain.Entities
{
    public abstract class EntityCommon:IEntity
    {
        public long Id { get; set; }
        public string? CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public string? LastModifiedBy { get; set; }
        public DateTime? LastModifiedDate { get; set; }
    }
}
