namespace Ratiocinia.Models
{
    using System.Numerics;
    using MathFoundations;

    /// <summary>
    /// Provides a default implementation of <see cref="IDivideTruncated{T}" /> that performs
    /// division in an unchecked context, allowing silent overflow.
    /// </summary>
    /// <typeparam name="T">The numeric type supporting division operations.</typeparam>
    public interface IUncheckedDivisionFunctions<T> : IDivideTruncated<T>
        where T : IDivisionOperators<T, T, T>
    {
        /// <inheritdoc />
        T IDivideTruncated<T>.DivideTruncated(T left, T right) => left / right;
    }
}
