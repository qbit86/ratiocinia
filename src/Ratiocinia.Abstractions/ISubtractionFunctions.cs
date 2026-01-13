namespace Ratiocinia
{
    /// <summary>
    /// Defines a mechanism for computing the difference of two values.
    /// </summary>
    /// <typeparam name="T">The type of values to subtract.</typeparam>
    public interface ISubtractionFunctions<T>
    {
        /// <summary>
        /// Subtracts one value from another.
        /// </summary>
        /// <param name="left">The value to subtract from (the minuend).</param>
        /// <param name="right">The value to subtract (the subtrahend).</param>
        /// <returns>The difference of <paramref name="left" /> and <paramref name="right" />.</returns>
        T Subtract(T left, T right);
    }
}
