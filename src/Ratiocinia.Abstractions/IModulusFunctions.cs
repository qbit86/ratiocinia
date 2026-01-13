namespace Ratiocinia
{
    /// <summary>
    /// Defines a mechanism for computing the modulus (remainder) of two values.
    /// </summary>
    /// <typeparam name="T">The type of values to compute the modulus of.</typeparam>
    public interface IModulusFunctions<T>
    {
        /// <summary>
        /// Computes the modulus (remainder) of two values.
        /// </summary>
        /// <param name="left">The value to be divided (the dividend).</param>
        /// <param name="right">The value to divide by (the divisor).</param>
        /// <returns>The remainder of <paramref name="left" /> divided by <paramref name="right" />.</returns>
        T Modulus(T left, T right);
    }
}
