namespace Ratiocinia.Models
{
    using System.Numerics;
    using MathFoundations;

    /// <summary>
    /// Provides a default implementation of <see cref="IRemainderEuclidean{T}" /> for types
    /// that implement <see cref="IModulusOperators{TSelf,TOther,TResult}" />, using the modulus operator.
    /// </summary>
    /// <typeparam name="T">The numeric type that supports modulus operations.</typeparam>
    public interface INumericModulusFunctions<T> : IRemainderTruncated<T>
        where T : IModulusOperators<T, T, T>
    {
        /// <inheritdoc />
        T IRemainderTruncated<T>.RemainderTruncated(T left, T right) => left % right;
    }
}
