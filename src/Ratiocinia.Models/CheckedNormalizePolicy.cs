namespace Ratiocinia.Models
{
    using System;
    using System.Numerics;

    /// <summary>
    /// Provides arithmetic policy implementations with checked division and negation semantics for type <typeparamref name="T" />,
    /// suitable for normalizing rational numbers.
    /// Arithmetic operations are performed in a checked context and may throw <see cref="OverflowException" /> on overflow.
    /// </summary>
    /// <typeparam name="T">The numeric type for which arithmetic operations are provided.</typeparam>
    public sealed class CheckedNormalizePolicy<T> :
        ICheckedDivisionFunctions<T>,
        ICheckedUnaryNegationFunctions<T>,
        IComparableGreatestCommonDivisorFunctions<T>
        where T :
        IAdditiveIdentity<T, T>,
        IDivisionOperators<T, T, T>,
        IComparable<T>,
        IModulusOperators<T, T, T>,
        IUnaryNegationOperators<T, T>
    {
        /// <summary>
        /// Gets the singleton instance of the <see cref="CheckedNormalizePolicy{T}" /> class.
        /// </summary>
        public static CheckedNormalizePolicy<T> Instance { get; } = new();
    }
}
