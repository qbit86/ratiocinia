namespace Ratiocinia.Models
{
    using System.Numerics;
    using MathFoundations;

    /// <summary>
    /// Provides a default implementation of <see cref="INegate{T}" /> that performs
    /// negation in a checked context, throwing <see cref="System.OverflowException" /> on overflow.
    /// </summary>
    /// <typeparam name="T">The numeric type supporting unary negation operations.</typeparam>
    public interface ICheckedUnaryNegationFunctions<T> : INegate<T>
        where T : IUnaryNegationOperators<T, T>
    {
        /// <inheritdoc />
        T INegate<T>.Negate(T value) => checked(-value);
    }
}
