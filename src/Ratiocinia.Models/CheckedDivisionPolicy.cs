namespace Ratiocinia.Models
{
    using System;
    using System.Numerics;

    /// <summary>
    /// Provides arithmetic policy implementations with checked division semantics for type <typeparamref name="T" />.
    /// Arithmetic operations are performed in a checked context and may throw <see cref="OverflowException" /> on overflow.
    /// </summary>
    /// <typeparam name="T">The numeric type for which arithmetic operations are provided.</typeparam>
    public sealed class CheckedDivisionPolicy<T> :
        ICheckedDivisionFunctions<T>,
        ICheckedMultiplyFunctions<T>,
        ICheckedUnaryNegationFunctions<T>,
        IComparableGreatestCommonDivisorFunctions<T>
        where T :
        IAdditiveIdentity<T, T>,
        IDivisionOperators<T, T, T>,
        IComparable<T>,
        IModulusOperators<T, T, T>,
        IMultiplyOperators<T, T, T>,
        IUnaryNegationOperators<T, T>
    {
        /// <summary>
        /// Gets the singleton instance of the <see cref="CheckedDivisionPolicy{T}" /> class.
        /// </summary>
        public static CheckedDivisionPolicy<T> Instance { get; } = new();
    }
}
