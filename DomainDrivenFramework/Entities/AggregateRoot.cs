using DomainDrivenFramework.DomainEvents;

namespace DomainDrivenFramework.Entities
{
    public abstract class AggregateRoot : EntityBase
    {
        protected AggregateRoot() : this(Guid.NewGuid())
        {

        }

        protected AggregateRoot(Guid id)
        {
            Id = id;
        }

        private readonly List<DomainEvent> _domainEvents = [];
        public IReadOnlyCollection<DomainEvent> DomainEvents => _domainEvents.AsReadOnly();

        public void AddDomainEvent(DomainEvent eventItem)
        {
            _domainEvents.Add(eventItem);
        }

        public void ClearDomainEvents()
        {
            _domainEvents.Clear();
        }
    }

    public abstract class AggregateRoot<TId> : EntityBase<TId>
        where TId : IComparable<TId>
    {
        protected AggregateRoot()
        {

        }

        protected AggregateRoot(TId id)
        {
            Id = id;
        }
    }
}
