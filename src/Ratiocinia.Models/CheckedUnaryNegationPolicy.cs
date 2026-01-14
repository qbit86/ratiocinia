namespace Ratiocinia.Models
{
    using System.Numerics;

    /// <summary>
    /// Provides arithmetic policy implementations with checked unary negation semantics for type <typeparamref name="T" />.
    /// Negation is performed in a checked context and may throw <see cref="System.OverflowException" /> on overflow.
    /// </summary>
    /// <typeparam name="T">The numeric type for which the negation operation is provided.</typeparam>
    public sealed class CheckedUnaryNegationPolicy<T> : ICheckedUnaryNegationFunctions<T>
        where T : IUnaryNegationOperators<T, T>
    {
        /// <summary>
        /// Gets the singleton instance of the <see cref="CheckedUnaryNegationPolicy{T}" /> class.
        /// </summary>
        public static CheckedUnaryNegationPolicy<T> Instance { get; } = new();
    }
}
