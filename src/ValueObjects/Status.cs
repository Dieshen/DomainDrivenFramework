using DomainDrivenFramework.Guards;

namespace DomainDrivenFramework.ValueObjects
{
    public sealed class Status : ValueObject
    {
        private Status(int id, string name)
        {
            Id = id;
            Name = name;
        }

        public int Id { get; private set; }
        public string Name { get; private set; }

        public static Status Create(int id, string name)
        {
            Guard.Against.LessThan(id, 1, nameof(Id));
            name = (name ?? string.Empty).Trim();
            Guard.Against.NullOrEmpty(name, nameof(Name));

            return new Status(id, name);
        }

        public static Status Create(Enum @enum)
        {
            return Create((int)(object)@enum, @enum.ToString());
        }

        protected override IEnumerable<IComparable> GetEqualityComponents()
        {
            yield return Id;
            yield return Name;
        }

        public static bool operator ==(Status a, Enum b)
        {
            return a.Id == (int)(object)b && a.Name == b.ToString();
        }

        public static bool operator !=(Status a, Enum b)
        {
            return a.Id != (int)(object)b || a.Name != b.ToString();
        }

        public override bool Equals(object? obj)
        {
            if (obj is Enum @enum)
            {
                return this == @enum;
            }

            return base.Equals(obj);
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
}
