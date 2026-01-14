namespace Ratiocinia.Models
{
    using System.Numerics;

    /// <summary>
    /// Provides a default implementation of <see cref="IModulusFunctions{T}" /> for types
    /// that implement <see cref="IModulusOperators{TSelf,TOther,TResult}" />, using the modulus operator.
    /// </summary>
    /// <typeparam name="T">The numeric type that supports modulus operations.</typeparam>
    public interface INumericModulusFunctions<T> : IModulusFunctions<T>
        where T : IModulusOperators<T, T, T>
    {
        /// <inheritdoc />
        T IModulusFunctions<T>.Modulus(T left, T right) => left % right;
    }
}
