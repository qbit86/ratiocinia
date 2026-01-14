namespace Ratiocinia.Models
{
    using System.Numerics;

    /// <summary>
    /// Provides a default implementation of <see cref="IDecrementFunctions{T}" /> that performs
    /// decrement in a checked context, throwing <see cref="System.OverflowException" /> on overflow.
    /// </summary>
    /// <typeparam name="T">The numeric type supporting decrement operations.</typeparam>
    public interface ICheckedDecrementFunctions<T> : IDecrementFunctions<T>
        where T : IDecrementOperators<T>
    {
        /// <inheritdoc />
        T IDecrementFunctions<T>.Decrement(T value) => checked(--value);
    }
}
