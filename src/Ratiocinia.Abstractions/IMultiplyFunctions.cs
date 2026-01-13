namespace Ratiocinia
{
    /// <summary>
    /// Defines a mechanism for computing the product of two values.
    /// </summary>
    /// <typeparam name="T">The type of values to multiply.</typeparam>
    public interface IMultiplyFunctions<T>
    {
        /// <summary>
        /// Multiplies two values together.
        /// </summary>
        /// <param name="left">The first value to multiply.</param>
        /// <param name="right">The second value to multiply.</param>
        /// <returns>The product of <paramref name="left" /> and <paramref name="right" />.</returns>
        T Multiply(T left, T right);
    }
}
