using DomainDrivenFramework.ValueObjects;

namespace DomainDrivenFramework.Entities
{
    public abstract class EntityBase : EntityBase<Guid>
    {

    }

    public abstract class EntityBase<TId> : IComparable, IComparable<EntityBase<TId>>
        where TId : IComparable<TId>
    {
        public virtual TId Id { get; protected set; } = default!;

        protected EntityBase()
        {
        }

        protected EntityBase(TId id)
        {
            Id = id;
        }

        public override bool Equals(object? obj)
        {
            EntityBase<TId>? entity = obj as EntityBase<TId>;
            if (entity is null)
            {
                return false;
            }

            if (this == entity)
            {
                return true;
            }

            if (ValueObject.GetUnproxiedType(this) != ValueObject.GetUnproxiedType(entity))
            {
                return false;
            }

            if (IsTransient() || entity.IsTransient())
            {
                return false;
            }

            return Id.Equals(entity.Id);
        }

        private bool IsTransient()
        {
            if (Id != null)
            {
                return Id.Equals(default(TId));
            }

            return true;
        }

        public static bool operator ==(EntityBase<TId> a, EntityBase<TId> b)
        {
            if (a is null && b is null)
            {
                return true;
            }

            if (a is null || b is null)
            {
                return false;
            }

            return a.Equals(b);
        }

        public static bool operator !=(EntityBase<TId> a, EntityBase<TId> b)
        {
            return !(a == b);
        }

        public override int GetHashCode()
        {
            return (ValueObject.GetUnproxiedType(this).ToString() + Id).GetHashCode();
        }

        public virtual int CompareTo(EntityBase<TId>? other)
        {
            if (other is null)
            {
                return 1;
            }

            if (this == other)
            {
                return 0;
            }

            return Id.CompareTo(other.Id);
        }

        public virtual int CompareTo(object? other)
        {
            return CompareTo(other as EntityBase<TId>);
        }
    }
}
