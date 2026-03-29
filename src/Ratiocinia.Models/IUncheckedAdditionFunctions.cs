namespace Ratiocinia.Models
{
    using System.Numerics;
    using MathFoundations;

    /// <summary>
    /// Provides a default implementation of <see cref="IAdd{T}" /> that performs
    /// addition in an unchecked context, allowing silent overflow.
    /// </summary>
    /// <typeparam name="T">The numeric type supporting addition operations.</typeparam>
    public interface IUncheckedAdditionFunctions<T> : IAdd<T>
        where T : IAdditionOperators<T, T, T>
    {
        /// <inheritdoc />
        T IAdd<T>.Add(T a, T b) => a + b;
    }
}
