namespace Ratiocinia.Models
{
    using System.Numerics;

    /// <summary>
    /// Provides a default implementation of <see cref="IDecrementFunctions{T}" /> that performs
    /// decrement in an unchecked context, allowing silent overflow.
    /// </summary>
    /// <typeparam name="T">The numeric type supporting decrement operations.</typeparam>
    public interface IUncheckedDecrementFunctions<T> : IDecrementFunctions<T>
        where T : IDecrementOperators<T>
    {
        /// <inheritdoc />
        T IDecrementFunctions<T>.Decrement(T value) => --value;
    }
}
