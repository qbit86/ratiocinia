namespace Ratiocinia
{
    /// <summary>
    /// Defines a mechanism for computing the absolute value of a number.
    /// </summary>
    /// <typeparam name="T">The type of value to compute the absolute value of.</typeparam>
    public interface IAbsoluteFunctions<T>
    {
        /// <summary>
        /// Computes the absolute value of a number.
        /// </summary>
        /// <param name="value">The value for which to compute the absolute value.</param>
        /// <returns>The absolute value of <paramref name="value" />.</returns>
        T Abs(T value);
    }
}
