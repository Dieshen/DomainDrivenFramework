using Coyotl.Core.Abstractions.Guards;
using DomainDrivenFramework.Guards;

namespace DomainDrivenFramework.ValueObjects
{
    public sealed class Address : ValueObject
    {
        private Address(string street1, string? street2, string city, string? state, string zipCode, string country)
        {
            Street1 = street1;
            Street2 = street2;
            City = city;
            State = state;
            ZipCode = zipCode;
            Country = country;
        }

        public string Street1 { get; private set; }
        public string? Street2 { get; private set; }
        public string City { get; private set; }
        public string? State { get; private set; }
        public string ZipCode { get; private set; }
        public string Country { get; private set; }

        public static Address Create(string street1, string? street2, string city, string? state, string zipCode, string country)
        {
            street1 = (street1 ?? string.Empty).Trim();
            Guard.Against.NullOrEmpty(street1, nameof(street1));
            city = (city ?? string.Empty).Trim();
            Guard.Against.NullOrEmpty(city, nameof(city));
            zipCode = (zipCode ?? string.Empty).Trim();
            Guard.Against.NullOrEmpty(zipCode, nameof(zipCode));
            country = (country ?? string.Empty).Trim();
            Guard.Against.NullOrEmpty(country, nameof(country));

            street2 = (street2 ?? string.Empty).Trim();
            state = (state ?? string.Empty).Trim();

            return new Address(street1, street2, city, state, zipCode, country);
        }

        protected override IEnumerable<IComparable> GetEqualityComponents()
        {
            yield return Street1;
            yield return Street2 ?? "";
            yield return City;
            yield return State ?? "";
            yield return ZipCode;
            yield return Country;
        }
    }
}
