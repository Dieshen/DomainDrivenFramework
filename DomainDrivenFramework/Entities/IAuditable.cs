using DomainDrivenFramework.ValueObjects;

namespace DomainDrivenFramework.Entities
{
    public interface IAuditable
    {
        DateTime Created { get; }
        Name CreatedBy { get; }
        DateTime? LastModified { get; }
        Name? LastModifiedBy { get; }
        bool IsDeleted { get; }
        bool IsArchived { get; }
    }
}
