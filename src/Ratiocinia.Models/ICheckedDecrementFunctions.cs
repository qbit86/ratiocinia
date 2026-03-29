namespace Ratiocinia.Models
{
    using System.Numerics;
    using MathFoundations;

    /// <summary>
    /// Provides a default implementation of <see cref="IDecrement{T}" /> that performs
    /// decrement in a checked context, throwing <see cref="System.OverflowException" /> on overflow.
    /// </summary>
    /// <typeparam name="T">The numeric type supporting decrement operations.</typeparam>
    public interface ICheckedDecrementFunctions<T> : IDecrement<T>
        where T : IDecrementOperators<T>
    {
        /// <inheritdoc />
        T IDecrement<T>.Decrement(T value) => checked(--value);
    }
}
