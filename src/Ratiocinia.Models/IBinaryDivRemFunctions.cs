namespace Ratiocinia.Models
{
    using System.Numerics;

    /// <summary>
    /// Provides a default implementation of <see cref="IDivRemFunctions{T}" /> for binary integer types
    /// using <see cref="IBinaryInteger{TSelf}.DivRem(TSelf, TSelf)" />.
    /// </summary>
    /// <typeparam name="T">The binary integer type.</typeparam>
    public interface IBinaryDivRemFunctions<T> : IDivRemFunctions<T>
        where T : IBinaryInteger<T>
    {
        /// <inheritdoc />
        (T Quotient, T Remainder) IDivRemFunctions<T>.DivRem(T left, T right) => T.DivRem(left, right);
    }
}
