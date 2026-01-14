namespace Ratiocinia.Models
{
    using System.Numerics;

    /// <summary>
    /// Provides a default implementation of <see cref="IUnaryNegationFunctions{T}" /> that performs
    /// negation in a checked context, throwing <see cref="System.OverflowException" /> on overflow.
    /// </summary>
    /// <typeparam name="T">The numeric type supporting unary negation operations.</typeparam>
    public interface ICheckedUnaryNegationFunctions<T> : IUnaryNegationFunctions<T>
        where T : IUnaryNegationOperators<T, T>
    {
        /// <inheritdoc />
        T IUnaryNegationFunctions<T>.Negate(T value) => checked(-value);
    }
}
