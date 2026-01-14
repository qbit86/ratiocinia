namespace Ratiocinia.Models
{
    using System;
    using System.Numerics;

    /// <summary>
    /// Provides arithmetic policy implementations with unchecked subtraction semantics for type <typeparamref name="T" />.
    /// Arithmetic operations are performed in an unchecked context and may silently overflow.
    /// </summary>
    /// <typeparam name="T">The numeric type for which arithmetic operations are provided.</typeparam>
    public sealed class UncheckedSubtractionPolicy<T> :
        IEquatableGreatestCommonDivisorFunctions<T>,
        IUncheckedDivisionFunctions<T>,
        IUncheckedMultiplyFunctions<T>,
        IUncheckedSubtractionFunctions<T>
        where T :
        IAdditiveIdentity<T, T>,
        IDivisionOperators<T, T, T>,
        IEquatable<T>,
        IModulusOperators<T, T, T>,
        IMultiplyOperators<T, T, T>,
        ISubtractionOperators<T, T, T>
    {
        /// <summary>
        /// Gets the singleton instance of the <see cref="UncheckedSubtractionPolicy{T}" /> class.
        /// </summary>
        public static UncheckedSubtractionPolicy<T> Instance { get; } = new();
    }
}
