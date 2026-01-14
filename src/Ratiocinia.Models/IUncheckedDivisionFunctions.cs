namespace Ratiocinia.Models
{
    using System.Numerics;

    /// <summary>
    /// Provides a default implementation of <see cref="IDivisionFunctions{T}" /> that performs
    /// division in an unchecked context, allowing silent overflow.
    /// </summary>
    /// <typeparam name="T">The numeric type supporting division operations.</typeparam>
    public interface IUncheckedDivisionFunctions<T> : IDivisionFunctions<T>
        where T : IDivisionOperators<T, T, T>
    {
        /// <inheritdoc />
        T IDivisionFunctions<T>.Divide(T left, T right) => left / right;
    }
}
