namespace Ratiocinia.Models
{
    using System;
    using System.Numerics;

    /// <summary>
    /// Provides arithmetic policy implementations with unchecked addition and decrement semantics for type <typeparamref name="T" />,
    /// along with comparison and DivRem operations for less-than comparisons.
    /// Arithmetic operations are performed in an unchecked context and may silently overflow.
    /// </summary>
    /// <typeparam name="T">The binary integer type for which arithmetic operations are provided.</typeparam>
    public sealed class UncheckedLessThanPolicy<T> :
        IBinaryDivRemFunctions<T>,
        IComparableComparer<T>,
        IUncheckedAdditionFunctions<T>,
        IUncheckedDecrementFunctions<T>
        where T :
        IAdditionOperators<T, T, T>,
        IBinaryInteger<T>,
        IComparable<T>,
        IDecrementOperators<T>,
        IDivisionOperators<T, T, T>,
        IModulusOperators<T, T, T>
    {
        /// <summary>
        /// Gets the singleton instance of the <see cref="UncheckedLessThanPolicy{T}" /> class.
        /// </summary>
        public static UncheckedLessThanPolicy<T> Instance { get; } = new();
    }
}
