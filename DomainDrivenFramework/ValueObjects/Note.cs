namespace DomainDrivenFramework.ValueObjects
{
    public sealed class Note : ValueObject
    {
        public string Value { get; }

        public Note(string value)
        {
            Value = value;
        }

        public static implicit operator string(Note note) => note.Value;

        public static explicit operator Note(string value) => new(value);
        public override string ToString() => Value;

        protected override IEnumerable<IComparable> GetEqualityComponents()
        {
            yield return Value;
        }
    }
}
