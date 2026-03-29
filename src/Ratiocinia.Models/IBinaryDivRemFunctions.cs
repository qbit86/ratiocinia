namespace Ratiocinia.Models
{
    using System.Numerics;
    using MathFoundations;

    /// <summary>
    /// Provides a default implementation of <see cref="IDivRemTruncated{T}" /> for binary integer types
    /// using <see cref="IBinaryInteger{TSelf}.DivRem(TSelf, TSelf)" />.
    /// </summary>
    /// <typeparam name="T">The binary integer type.</typeparam>
    public interface IBinaryDivRemFunctions<T> : IDivRemTruncated<T>
        where T : IBinaryInteger<T>
    {
        /// <inheritdoc />
        (T Quotient, T Remainder) IDivRemTruncated<T>.DivRemTruncated(T left, T right) => T.DivRem(left, right);
    }
}
