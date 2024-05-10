using DomainDrivenFramework.Exceptions;
using System.Net.Mail;

namespace DomainDrivenFramework.ValueObjects
{
    public sealed class Email : ValueObject
    {
        private Email(string email)
        {
            Value = email;
        }

        public string Value { get; private set; }

        public static Email Create(string email)
        {
            try
            {
                _ = new MailAddress(email);
            }
            catch
            {
                throw new DomainException("Invalid email address.");
            }

            return new Email(email);
        }

        protected override IEnumerable<IComparable> GetEqualityComponents()
        {
            yield return Value;
        }
    }
}
