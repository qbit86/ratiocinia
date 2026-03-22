namespace Ratiocinia.Models
{
    using System.Numerics;
    using MathFoundations;
    /// <summary>
    /// Provides a default implementation of <see cref="IDivideTruncated{T}" /> that performs
    /// division in a checked context, throwing <see cref="System.OverflowException" /> on overflow.
    /// </summary>
    /// <typeparam name="T">The numeric type supporting division operations.</typeparam>
    public interface ICheckedDivisionFunctions<T> : IDivideTruncated<T>
        where T : IDivisionOperators<T, T, T>
    {
        /// <inheritdoc />
        T IDivideTruncated<T>.DivideTruncated(T left, T right) => checked(left / right);
    }
}
