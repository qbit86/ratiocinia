namespace Ratiocinia.Models
{
    using System.Numerics;
    using MathFoundations;
    /// <summary>
    /// Provides a default implementation of <see cref="ISubtract{T}" /> that performs
    /// subtraction in a checked context, throwing <see cref="System.OverflowException" /> on overflow.
    /// </summary>
    /// <typeparam name="T">The numeric type supporting subtraction operations.</typeparam>
    public interface ICheckedSubtractionFunctions<T> : ISubtract<T>
        where T : ISubtractionOperators<T, T, T>
    {
        /// <inheritdoc />
        T ISubtract<T>.Subtract(T left, T right) => checked(left - right);
    }
}
