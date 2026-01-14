namespace Ratiocinia.Models
{
    using System.Numerics;

    /// <summary>
    /// Provides a default implementation of <see cref="IAdditionFunctions{T}" /> that performs
    /// addition in an unchecked context, allowing silent overflow.
    /// </summary>
    /// <typeparam name="T">The numeric type supporting addition operations.</typeparam>
    public interface IUncheckedAdditionFunctions<T> : IAdditionFunctions<T>
        where T : IAdditionOperators<T, T, T>
    {
        /// <inheritdoc />
        T IAdditionFunctions<T>.Add(T left, T right) => left + right;
    }
}
