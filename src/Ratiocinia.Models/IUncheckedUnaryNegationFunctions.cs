namespace Ratiocinia.Models
{
    using System.Numerics;

    /// <summary>
    /// Provides a default implementation of <see cref="IUnaryNegationFunctions{T}" /> that performs
    /// negation in an unchecked context, allowing silent overflow.
    /// </summary>
    /// <typeparam name="T">The numeric type supporting unary negation operations.</typeparam>
    public interface IUncheckedUnaryNegationFunctions<T> : IUnaryNegationFunctions<T>
        where T : IUnaryNegationOperators<T, T>
    {
        /// <inheritdoc />
        T IUnaryNegationFunctions<T>.Negate(T value) => -value;
    }
}
