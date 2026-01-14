namespace Ratiocinia.Models
{
    using System;
    using System.Numerics;

    /// <summary>
    /// Provides arithmetic policy implementations with checked subtraction semantics for type <typeparamref name="T" />.
    /// Arithmetic operations are performed in a checked context and may throw <see cref="OverflowException" /> on overflow.
    /// </summary>
    /// <typeparam name="T">The numeric type for which arithmetic operations are provided.</typeparam>
    public sealed class CheckedSubtractionPolicy<T> :
        ICheckedDivisionFunctions<T>,
        ICheckedMultiplyFunctions<T>,
        ICheckedSubtractionFunctions<T>,
        IEquatableGreatestCommonDivisorFunctions<T>
        where T :
        IAdditiveIdentity<T, T>,
        IDivisionOperators<T, T, T>,
        IEquatable<T>,
        IModulusOperators<T, T, T>,
        IMultiplyOperators<T, T, T>,
        ISubtractionOperators<T, T, T>
    {
        /// <summary>
        /// Gets the singleton instance of the <see cref="CheckedSubtractionPolicy{T}" /> class.
        /// </summary>
        public static CheckedSubtractionPolicy<T> Instance { get; } = new();
    }
}
