namespace DomainDrivenFramework.ValueObjects
{
    public sealed class Contact : ValueObject
    {
        private Contact(Email email, Name name, Address? address, PhoneNumber? officeNumber, PhoneNumber? mobileNumber)
        {
            Email = email;
            Name = name;
            Address = address;
            OfficeNumber = officeNumber;
            MobileNumber = mobileNumber;
        }

        public Email Email { get; private set; }
        public Name Name { get; private set; }
        public Address? Address { get; private set; }
        public PhoneNumber? OfficeNumber { get; private set; }
        public PhoneNumber? MobileNumber { get; private set; }

        public static Contact Create(Email email, Name name, Address? address = null, PhoneNumber? officeNumber = null, PhoneNumber? mobileNumber = null)
        {
            return new Contact(email, name, address, officeNumber, mobileNumber);
        }

        protected override IEnumerable<IComparable> GetEqualityComponents()
        {
            yield return Email;
            yield return Name;
            if (Address is not null)
                yield return Address;
            if (OfficeNumber is not null)
                yield return OfficeNumber;
            if (MobileNumber is not null)
                yield return MobileNumber;
        }
    }
}
