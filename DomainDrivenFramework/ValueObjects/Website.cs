using Coyotl.Core.Abstractions.Guards;
using DomainDrivenFramework.Guards;
using System.Text.RegularExpressions;

namespace DomainDrivenFramework.ValueObjects
{
    public sealed class Website
    {
        // Regex pattern for website validation
        private static readonly Regex _regex = new(@"^(https?://)?([\w-]+\.)+[\w-]+(/[\w- ./?%&=]*)?$");

        private Website(string website)
        {
            Value = website;
        }

        public string Value { get; private set; }

        public static Website Create(string website)
        {
            website = (website ?? string.Empty).Trim();
            Guard.Against.NullOrEmpty(website, nameof(Website));
            ValidateWebsite(website);

            return new Website(website);
        }

        private static void ValidateWebsite(string website)
        {
            website = (website ?? string.Empty).Trim();
            Guard.Against.NullOrEmpty(website, nameof(Website));
            Guard.Against.False(_regex.IsMatch(website), nameof(Website), "Invalid website.");
        }
    }
}
