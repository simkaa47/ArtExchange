﻿namespace ArtExchange.Domain.Entities.Common
{
    public abstract class EntityCommon
    {
        public long Id { get; set; }
        public string? CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public string? LastModifiedBy { get; set; }
        public DateTime? LastModifiedDate { get; set; }
    }
}
