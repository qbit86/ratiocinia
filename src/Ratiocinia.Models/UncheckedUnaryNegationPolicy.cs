namespace Ratiocinia.Models
{
    using System.Numerics;

    /// <summary>
    /// Provides arithmetic policy implementations with unchecked unary negation semantics for type <typeparamref name="T" />.
    /// Negation is performed in an unchecked context and may silently overflow.
    /// </summary>
    /// <typeparam name="T">The numeric type for which the negation operation is provided.</typeparam>
    public sealed class UncheckedUnaryNegationPolicy<T> : IUncheckedUnaryNegationFunctions<T>
        where T : IUnaryNegationOperators<T, T>
    {
        /// <summary>
        /// Gets the singleton instance of the <see cref="UncheckedUnaryNegationPolicy{T}" /> class.
        /// </summary>
        public static UncheckedUnaryNegationPolicy<T> Instance { get; } = new();
    }
}
