namespace Ratiocinia.Models
{
    using System.Numerics;

    /// <summary>
    /// Provides a default implementation of <see cref="ISubtractionFunctions{T}" /> that performs
    /// subtraction in an unchecked context, allowing silent overflow.
    /// </summary>
    /// <typeparam name="T">The numeric type supporting subtraction operations.</typeparam>
    public interface IUncheckedSubtractionFunctions<T> : ISubtractionFunctions<T>
        where T : ISubtractionOperators<T, T, T>
    {
        /// <inheritdoc />
        T ISubtractionFunctions<T>.Subtract(T left, T right) => left - right;
    }
}
