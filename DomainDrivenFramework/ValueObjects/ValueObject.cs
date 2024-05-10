namespace DomainDrivenFramework.ValueObjects
{
    [Serializable]
    public abstract class ValueObject : IComparable, IComparable<ValueObject>
    {
        private int? _cachedHashCode;

        protected abstract IEnumerable<IComparable> GetEqualityComponents();

        public override bool Equals(object? obj)
        {
            if (obj is null)
            {
                return false;
            }

            if (GetUnproxiedType(this) != GetUnproxiedType(obj))
            {
                return false;
            }

            ValueObject valueObject = (ValueObject)obj;
            return GetEqualityComponents().SequenceEqual(valueObject.GetEqualityComponents());
        }

        public override int GetHashCode()
        {
            if (!_cachedHashCode.HasValue)
            {
                _cachedHashCode = GetEqualityComponents().Aggregate(1, (current, obj) => current * 23 + (obj?.GetHashCode() ?? 0));
            }

            return _cachedHashCode.Value;
        }

        public virtual int CompareTo(ValueObject? other)
        {
            if (other is null)
            {
                return 1;
            }

            if (this == other)
            {
                return 0;
            }

            Type unproxiedType = GetUnproxiedType(this);
            Type unproxiedType2 = GetUnproxiedType(other);
            if (unproxiedType != unproxiedType2)
            {
                return string.Compare($"{unproxiedType}", $"{unproxiedType2}", StringComparison.Ordinal);
            }

            return GetEqualityComponents().Zip(other.GetEqualityComponents(), (left, right) => left?.CompareTo(right) ?? (right != null ? -1 : 0)).FirstOrDefault((cmp) => cmp != 0);
        }

        public virtual int CompareTo(object? other)
        {
            return CompareTo(other as ValueObject);
        }

        public static bool operator ==(ValueObject a, ValueObject b)
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

        public static bool operator !=(ValueObject a, ValueObject b)
        {
            return !(a == b);
        }

        internal static Type GetUnproxiedType(object obj)
        {
            Type type = obj.GetType();
            string text = type.ToString();
            if (text.Contains("Castle.Proxies.") || text.EndsWith("Proxy"))
            {
                return type.BaseType!;
            }

            return type;
        }
    }
}
