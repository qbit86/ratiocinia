namespace Ratiocinia.Models
{
    using System.Numerics;

    /// <summary>
    /// Provides a default implementation of <see cref="ISubtractionFunctions{T}" /> that performs
    /// subtraction in a checked context, throwing <see cref="System.OverflowException" /> on overflow.
    /// </summary>
    /// <typeparam name="T">The numeric type supporting subtraction operations.</typeparam>
    public interface ICheckedSubtractionFunctions<T> : ISubtractionFunctions<T>
        where T : ISubtractionOperators<T, T, T>
    {
        /// <inheritdoc />
        T ISubtractionFunctions<T>.Subtract(T left, T right) => checked(left - right);
    }
}
