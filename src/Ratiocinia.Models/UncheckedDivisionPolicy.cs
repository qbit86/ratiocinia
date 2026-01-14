namespace Ratiocinia.Models
{
    using System;
    using System.Numerics;

    /// <summary>
    /// Provides arithmetic policy implementations with unchecked division semantics for type <typeparamref name="T" />.
    /// Arithmetic operations are performed in an unchecked context and may silently overflow.
    /// </summary>
    /// <typeparam name="T">The numeric type for which arithmetic operations are provided.</typeparam>
    public sealed class UncheckedDivisionPolicy<T> :
        IComparableGreatestCommonDivisorFunctions<T>,
        IUncheckedDivisionFunctions<T>,
        IUncheckedMultiplyFunctions<T>,
        IUncheckedUnaryNegationFunctions<T>
        where T :
        IAdditiveIdentity<T, T>,
        IDivisionOperators<T, T, T>,
        IComparable<T>,
        IModulusOperators<T, T, T>,
        IMultiplyOperators<T, T, T>,
        IUnaryNegationOperators<T, T>
    {
        /// <summary>
        /// Gets the singleton instance of the <see cref="UncheckedDivisionPolicy{T}" /> class.
        /// </summary>
        public static UncheckedDivisionPolicy<T> Instance { get; } = new();
    }
}
