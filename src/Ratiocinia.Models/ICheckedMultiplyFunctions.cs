namespace Ratiocinia.Models
{
    using System.Numerics;

    /// <summary>
    /// Provides a default implementation of <see cref="IMultiplyFunctions{T}" /> that performs
    /// multiplication in a checked context, throwing <see cref="System.OverflowException" /> on overflow.
    /// </summary>
    /// <typeparam name="T">The numeric type supporting multiplication operations.</typeparam>
    public interface ICheckedMultiplyFunctions<T> : IMultiplyFunctions<T>
        where T : IMultiplyOperators<T, T, T>
    {
        /// <inheritdoc />
        T IMultiplyFunctions<T>.Multiply(T left, T right) => checked(left * right);
    }
}
