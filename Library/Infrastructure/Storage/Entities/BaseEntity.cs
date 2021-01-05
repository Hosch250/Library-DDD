using System;

namespace Library.Infrastructure.Storage.Entities
{
    public record BaseEntity(string AuditInfo_CreatedBy, DateTime AuditInfo_CreatedOn)
    {
        public BaseEntity SetCreationAuditFields()
        {
            return this with
            {
                AuditInfo_CreatedBy = "Library.Web",
                AuditInfo_CreatedOn = DateTime.UtcNow
            };
        }
    }
}
