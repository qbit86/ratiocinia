namespace Ratiocinia.Models
{
    using System.Numerics;
    using MathFoundations;
    /// <summary>
    /// Provides a default implementation of <see cref="IGcd{T}" /> for types
    /// that implement <see cref="INumberBase{TSelf}" />, using the type's <see cref="INumberBase{TSelf}.IsZero(TSelf)" /> method.
    /// </summary>
    /// <typeparam name="T">The numeric type that implements <see cref="INumberBase{TSelf}" /> and supports modulus operations.</typeparam>
    public interface INumberBaseGreatestCommonDivisorFunctions<T> : IGcd<T>
        where T : IModulusOperators<T, T, T>, INumberBase<T>
    {
        /// <inheritdoc />
        T IGcd<T>.Gcd(T left, T right) => GreatestCommonDivisor.GcdNumberBase(left, right);
    }
}
