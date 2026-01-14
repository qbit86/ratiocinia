namespace Ratiocinia.Models
{
    using System;
    using System.Numerics;

    /// <summary>
    /// Provides arithmetic policy implementations with unchecked division and negation semantics for type <typeparamref name="T" />,
    /// suitable for normalizing rational numbers.
    /// Arithmetic operations are performed in an unchecked context and may silently overflow.
    /// </summary>
    /// <typeparam name="T">The numeric type for which arithmetic operations are provided.</typeparam>
    public sealed class UncheckedNormalizePolicy<T> :
        IComparableGreatestCommonDivisorFunctions<T>,
        IUncheckedDivisionFunctions<T>,
        IUncheckedUnaryNegationFunctions<T>
        where T :
        IAdditiveIdentity<T, T>,
        IDivisionOperators<T, T, T>,
        IComparable<T>,
        IModulusOperators<T, T, T>,
        IUnaryNegationOperators<T, T>
    {
        /// <summary>
        /// Gets the singleton instance of the <see cref="UncheckedNormalizePolicy{T}" /> class.
        /// </summary>
        public static UncheckedNormalizePolicy<T> Instance { get; } = new();
    }
}
