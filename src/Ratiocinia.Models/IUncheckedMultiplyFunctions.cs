namespace Ratiocinia.Models
{
    using System.Numerics;
    using MathFoundations;
    /// <summary>
    /// Provides a default implementation of <see cref="IMultiply{T}" /> that performs
    /// multiplication in an unchecked context, allowing silent overflow.
    /// </summary>
    /// <typeparam name="T">The numeric type supporting multiplication operations.</typeparam>
    public interface IUncheckedMultiplyFunctions<T> : IMultiply<T>
        where T : IMultiplyOperators<T, T, T>
    {
        /// <inheritdoc />
        T IMultiply<T>.Multiply(T left, T right) => left * right;
    }
}
