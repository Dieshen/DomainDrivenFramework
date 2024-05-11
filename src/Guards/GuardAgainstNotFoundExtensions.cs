namespace DomainDrivenFramework.Guards
{
    public static partial class GuardClauseExtensions
    {
        public static T NotFound<T>(this IGuardClause guardClause, T? aggregate, string? message = null) where T : class
        {
            if (aggregate == null)
            {
                NotFound(message ?? "Not found");
            }
            return aggregate!;
        }

        public static T NotFound<T>(this IGuardClause guardClause, T? aggregate, Guid Id) where T : class
        {
            if (aggregate == null)
            {
                NotFound($"'{typeof(T).Name}' with Id '{Id}' not found");
            }
            return aggregate!;
        }
    }
}
