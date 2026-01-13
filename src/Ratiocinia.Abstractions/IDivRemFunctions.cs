namespace Ratiocinia
{
    /// <summary>
    /// Defines a mechanism for computing both the quotient and remainder of two values.
    /// </summary>
    /// <typeparam name="T">The type of values to divide.</typeparam>
    public interface IDivRemFunctions<T>
    {
        /// <summary>
        /// Computes the quotient and remainder of two values.
        /// </summary>
        /// <param name="left">The value to be divided (the dividend).</param>
        /// <param name="right">The value to divide by (the divisor).</param>
        /// <returns>A tuple containing the quotient and remainder of <paramref name="left" /> divided by <paramref name="right" />.</returns>
        (T Quotient, T Remainder) DivRem(T left, T right);
    }
}
