using DomainDrivenFramework.Guards;
using System.Text.RegularExpressions;

namespace DomainDrivenFramework.ValueObjects
{
    public sealed class PhoneNumber : ValueObject
    {
        private static readonly Regex _phoneNumberRegex = new(@"^(\d{3})-(\d{3})-(\d{4})$");
        private PhoneNumber(string number)
        {
            Value = number;
        }

        public string Value { get; private set; }

        public static PhoneNumber Create(string number)
        {
            number = (number ?? string.Empty).Trim();
            Guard.Against.NullOrEmpty(number, nameof(PhoneNumber));
            Guard.Against.False(_phoneNumberRegex.IsMatch(number), message: "Invalid phone number format.");

            return new PhoneNumber(number);
        }

        protected override IEnumerable<IComparable> GetEqualityComponents()
        {
            yield return Value;
        }
    }
}
