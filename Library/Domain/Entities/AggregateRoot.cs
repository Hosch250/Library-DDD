using Library.Infrastructure.Storage.Entities;
using System;

namespace Library.Domain.Entities
{
    public abstract class AggregateRoot
    {
        public string AuditInfo_CreatedBy { get; private set; } = "Library.Web";
        public DateTime AuditInfo_CreatedOn { get; private set; } = DateTime.UtcNow;

        public void SetCreatedBy(string createdBy)
        {
            AuditInfo_CreatedBy = createdBy;
        }
    }
}
