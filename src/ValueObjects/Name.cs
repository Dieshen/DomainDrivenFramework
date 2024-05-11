using DomainDrivenFramework.Guards;

namespace DomainDrivenFramework.ValueObjects
{
    public sealed class Name : ValueObject
    {
        private Name(string firstName, string lastName)
        {
            FirstName = firstName;
            LastName = lastName;
        }

        public string FirstName { get; private set; }
        public string LastName { get; private set; }

        public static Name Create(string firstName, string lastName)
        {
            firstName = (firstName ?? string.Empty).Trim();
            Guard.Against.NullOrEmpty(firstName, nameof(FirstName));
            lastName = (lastName ?? string.Empty).Trim();
            Guard.Against.NullOrEmpty(lastName, nameof(LastName));

            return new Name(firstName, lastName);
        }

        protected override IEnumerable<IComparable> GetEqualityComponents()
        {
            yield return FirstName;
            yield return LastName;
        }
    }
}
