namespace Ratiocinia.Models
{
    using System.Numerics;

    /// <summary>
    /// Provides a default implementation of <see cref="IDivisionFunctions{T}" /> that performs
    /// division in a checked context, throwing <see cref="System.OverflowException" /> on overflow.
    /// </summary>
    /// <typeparam name="T">The numeric type supporting division operations.</typeparam>
    public interface ICheckedDivisionFunctions<T> : IDivisionFunctions<T>
        where T : IDivisionOperators<T, T, T>
    {
        /// <inheritdoc />
        T IDivisionFunctions<T>.Divide(T left, T right) => checked(left / right);
    }
}
