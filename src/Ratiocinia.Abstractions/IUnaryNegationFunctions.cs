namespace Ratiocinia
{
    /// <summary>
    /// Defines a mechanism for computing the negation of a value.
    /// </summary>
    /// <typeparam name="T">The type of value to negate.</typeparam>
    public interface IUnaryNegationFunctions<T>
    {
        /// <summary>
        /// Computes the negation of a value.
        /// </summary>
        /// <param name="value">The value to negate.</param>
        /// <returns>The negation of <paramref name="value" />.</returns>
        T Negate(T value);
    }
}
