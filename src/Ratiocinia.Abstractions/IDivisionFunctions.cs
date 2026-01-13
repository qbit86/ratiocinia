namespace Ratiocinia
{
    /// <summary>
    /// Defines a mechanism for computing the quotient of two values.
    /// </summary>
    /// <typeparam name="T">The type of values to divide.</typeparam>
    public interface IDivisionFunctions<T>
    {
        /// <summary>
        /// Divides one value by another.
        /// </summary>
        /// <param name="left">The value to be divided (the dividend).</param>
        /// <param name="right">The value to divide by (the divisor).</param>
        /// <returns>The quotient of <paramref name="left" /> divided by <paramref name="right" />.</returns>
        T Divide(T left, T right);
    }
}
