namespace Ratiocinia
{
    /// <summary>
    /// Defines a mechanism for computing the greatest common divisor (GCD) of two values.
    /// </summary>
    /// <typeparam name="T">The type of values to compute the GCD of.</typeparam>
    public interface IGreatestCommonDivisorFunctions<T>
    {
        /// <summary>
        /// Computes the greatest common divisor of two values.
        /// </summary>
        /// <param name="left">The first value.</param>
        /// <param name="right">The second value.</param>
        /// <returns>The greatest common divisor of <paramref name="left" /> and <paramref name="right" />.</returns>
        T Gcd(T left, T right);
    }
}
