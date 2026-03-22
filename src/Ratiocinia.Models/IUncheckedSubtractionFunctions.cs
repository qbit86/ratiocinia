namespace Ratiocinia.Models
{
    using System.Numerics;
    using MathFoundations;
    /// <summary>
    /// Provides a default implementation of <see cref="ISubtract{T}" /> that performs
    /// subtraction in an unchecked context, allowing silent overflow.
    /// </summary>
    /// <typeparam name="T">The numeric type supporting subtraction operations.</typeparam>
    public interface IUncheckedSubtractionFunctions<T> : ISubtract<T>
        where T : ISubtractionOperators<T, T, T>
    {
        /// <inheritdoc />
        T ISubtract<T>.Subtract(T left, T right) => left - right;
    }
}
