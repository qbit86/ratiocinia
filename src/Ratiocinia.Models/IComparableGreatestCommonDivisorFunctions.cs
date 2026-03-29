namespace Ratiocinia.Models
{
    using System;
    using System.Numerics;
    using MathFoundations;

    /// <summary>
    /// Provides a default implementation of <see cref="IGcd{T}" /> for types
    /// that implement <see cref="IComparable{T}" />, using comparison to determine equality with zero.
    /// </summary>
    /// <typeparam name="T">The numeric type that supports comparison, additive identity, and modulus operations.</typeparam>
    public interface IComparableGreatestCommonDivisorFunctions<T> : IGcd<T>
        where T : IAdditiveIdentity<T, T>, IComparable<T>, IModulusOperators<T, T, T>, IUnaryNegationOperators<T, T>
    {
        /// <inheritdoc />
        T IGcd<T>.Gcd(T left, T right) => GreatestCommonDivisor.GcdComparable(left, right);
    }
}
