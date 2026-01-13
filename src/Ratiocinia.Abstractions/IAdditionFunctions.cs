namespace Ratiocinia
{
    /// <summary>
    /// Defines a mechanism for computing the sum of two values.
    /// </summary>
    /// <typeparam name="T">The type of values to add.</typeparam>
    public interface IAdditionFunctions<T>
    {
        /// <summary>
        /// Adds two values together.
        /// </summary>
        /// <param name="left">The first value to add.</param>
        /// <param name="right">The second value to add.</param>
        /// <returns>The sum of <paramref name="left" /> and <paramref name="right" />.</returns>
        T Add(T left, T right);
    }
}
