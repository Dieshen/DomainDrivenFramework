using DomainDrivenFramework.Guards;

namespace DomainDrivenFramework.ValueObjects
{
    public sealed class StoredFile : ValueObject
    {
        private StoredFile(string key)
        {
            Key = key;
        }

        public string Key { get; private set; }

        public static StoredFile Create(string key)
        {
            key = (key ?? string.Empty).Trim();
            Guard.Against.NullOrEmpty(key, nameof(Key));

            return new StoredFile(key);
        }

        protected override IEnumerable<IComparable> GetEqualityComponents()
        {
            yield return Key;
        }
    }
}
