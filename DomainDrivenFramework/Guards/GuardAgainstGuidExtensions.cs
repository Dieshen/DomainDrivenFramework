using DomainDrivenFramework.Guards;

namespace Coyotl.Core.Abstractions.Guards
{
    public static partial class GuardClauseExtensions
    {
        public static Guid Empty(this IGuardClause guardClause, Guid guid, string parameterName = "Value", string? message = null)
        {
            if (guid == Guid.Empty)
            {
                Error(message ?? $"'{parameterName}' can not be empty.");
            }
            return guid;
        }

    }
}
