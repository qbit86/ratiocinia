namespace Ratiocinia.Models
{
    using System;
    using System.Numerics;

    /// <summary>
    /// Provides arithmetic policy implementations with unchecked addition semantics for type <typeparamref name="T" />.
    /// Arithmetic operations are performed in an unchecked context and may silently overflow.
    /// </summary>
    /// <typeparam name="T">The numeric type for which arithmetic operations are provided.</typeparam>
    public sealed class UncheckedAdditionPolicy<T> :
        IUncheckedAdditionFunctions<T>,
        IUncheckedDivisionFunctions<T>,
        IUncheckedMultiplyFunctions<T>,
        IEquatableGreatestCommonDivisorFunctions<T>
        where T :
        IAdditionOperators<T, T, T>,
        IAdditiveIdentity<T, T>,
        IDivisionOperators<T, T, T>,
        IEquatable<T>,
        IModulusOperators<T, T, T>,
        IMultiplyOperators<T, T, T>
    {
        /// <summary>
        /// Gets the singleton instance of the <see cref="UncheckedAdditionPolicy{T}" /> class.
        /// </summary>
        public static UncheckedAdditionPolicy<T> Instance { get; } = new();
    }
}
