namespace Ratiocinia.Models
{
    using System;
    using System.Numerics;

    /// <summary>
    /// Provides arithmetic policy implementations with checked addition and decrement semantics for type <typeparamref name="T" />,
    /// along with comparison and DivRem operations for less-than comparisons.
    /// Arithmetic operations are performed in a checked context and may throw <see cref="OverflowException" /> on overflow.
    /// </summary>
    /// <typeparam name="T">The binary integer type for which arithmetic operations are provided.</typeparam>
    public sealed class CheckedLessThanPolicy<T> :
        IBinaryDivRemFunctions<T>,
        ICheckedAdditionFunctions<T>,
        ICheckedDecrementFunctions<T>,
        IComparableComparer<T>
        where T :
        IAdditionOperators<T, T, T>,
        IBinaryInteger<T>,
        IComparable<T>,
        IDecrementOperators<T>,
        IDivisionOperators<T, T, T>,
        IModulusOperators<T, T, T>
    {
        /// <summary>
        /// Gets the singleton instance of the <see cref="CheckedLessThanPolicy{T}" /> class.
        /// </summary>
        public static CheckedLessThanPolicy<T> Instance { get; } = new();
    }
}
