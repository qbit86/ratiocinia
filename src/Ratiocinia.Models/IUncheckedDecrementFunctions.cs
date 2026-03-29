namespace Ratiocinia.Models
{
    using System.Numerics;
    using MathFoundations;

    /// <summary>
    /// Provides a default implementation of <see cref="IDecrement{T}" /> that performs
    /// decrement in an unchecked context, allowing silent overflow.
    /// </summary>
    /// <typeparam name="T">The numeric type supporting decrement operations.</typeparam>
    public interface IUncheckedDecrementFunctions<T> : IDecrement<T>
        where T : IDecrementOperators<T>
    {
        /// <inheritdoc />
        T IDecrement<T>.Decrement(T value) => --value;
    }
}
