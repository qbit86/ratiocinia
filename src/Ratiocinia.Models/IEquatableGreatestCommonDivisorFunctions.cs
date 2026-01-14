namespace Ratiocinia.Models
{
    using System;
    using System.Numerics;

    /// <summary>
    /// Provides a default implementation of <see cref="IGreatestCommonDivisorFunctions{T}" /> for types
    /// that implement <see cref="IEquatable{T}" />, using equality to determine when a value equals zero.
    /// </summary>
    /// <typeparam name="T">The numeric type that supports equality, additive identity, and modulus operations.</typeparam>
    public interface IEquatableGreatestCommonDivisorFunctions<T> : IGreatestCommonDivisorFunctions<T>
        where T : IAdditiveIdentity<T, T>, IEquatable<T>, IModulusOperators<T, T, T>
    {
        /// <inheritdoc />
        T IGreatestCommonDivisorFunctions<T>.Gcd(T left, T right) => GreatestCommonDivisor.GcdEquatable(left, right);
    }
}
