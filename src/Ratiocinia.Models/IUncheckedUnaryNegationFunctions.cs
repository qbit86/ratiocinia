namespace Ratiocinia.Models
{
    using System.Numerics;
    using MathFoundations;

    /// <summary>
    /// Provides a default implementation of <see cref="INegate{T}" /> that performs
    /// negation in an unchecked context, allowing silent overflow.
    /// </summary>
    /// <typeparam name="T">The numeric type supporting unary negation operations.</typeparam>
    public interface IUncheckedUnaryNegationFunctions<T> : INegate<T>
        where T : IUnaryNegationOperators<T, T>
    {
        /// <inheritdoc />
        T INegate<T>.Negate(T value) => -value;
    }
}
