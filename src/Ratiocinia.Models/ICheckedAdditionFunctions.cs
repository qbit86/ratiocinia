namespace Ratiocinia.Models
{
    using System.Numerics;

    /// <summary>
    /// Provides a default implementation of <see cref="IAdditionFunctions{T}" /> that performs
    /// addition in a checked context, throwing <see cref="System.OverflowException" /> on overflow.
    /// </summary>
    /// <typeparam name="T">The numeric type supporting addition operations.</typeparam>
    public interface ICheckedAdditionFunctions<T> : IAdditionFunctions<T>
        where T : IAdditionOperators<T, T, T>
    {
        /// <inheritdoc />
        T IAdditionFunctions<T>.Add(T left, T right) => checked(left + right);
    }
}
