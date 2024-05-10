using DomainDrivenFramework.Guards;

namespace Coyotl.Core.Abstractions.Guards
{
    public static partial class GuardClauseExtensions
    {
        public static bool True(this IGuardClause guardClause, bool boolean, string parameterName = "Value", string? message = null)
        {
            if (boolean)
            {
                Error(message ?? $"'{parameterName}' can not be true.");
            }
            return boolean;
        }


        public static bool False(this IGuardClause guardClause, bool boolean, string parameterName = "Value", string? message = null)
        {
            if (!boolean)
            {
                Error(message ?? $"'{parameterName}' can not be false.");
            }
            return boolean;
        }
    }
}
