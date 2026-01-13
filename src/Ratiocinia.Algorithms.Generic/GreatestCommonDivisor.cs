namespace Ratiocinia.Algorithms.Generic
{
    using System;

    /// <summary>
    /// Provides a generic implementation of the greatest common divisor (GCD) algorithm.
    /// </summary>
    public static class GreatestCommonDivisor
    {
        /// <summary>
        /// Computes the greatest common divisor of two values using the Euclidean algorithm.
        /// </summary>
        /// <typeparam name="T">The type of the values.</typeparam>
        /// <typeparam name="TAdditiveIdentity">The type representing the additive identity (zero), which must be equatable to <typeparamref name="T" />.</typeparam>
        /// <typeparam name="TPolicy">The policy type providing the modulus operation.</typeparam>
        /// <param name="left">The first value.</param>
        /// <param name="right">The second value.</param>
        /// <param name="identity">The additive identity (zero) used to detect termination.</param>
        /// <param name="policy">The policy providing arithmetic operations.</param>
        /// <returns>The greatest common divisor of <paramref name="left" /> and <paramref name="right" />.</returns>
        public static T Gcd<T, TAdditiveIdentity, TPolicy>(
            T left, T right, TAdditiveIdentity identity, TPolicy policy)
#if NET9_0_OR_GREATER
            where TAdditiveIdentity : IEquatable<T>, allows ref struct
            where TPolicy : IModulusFunctions<T>, allows ref struct
#else
            where TAdditiveIdentity : IEquatable<T>
            where TPolicy : IModulusFunctions<T>
#endif
        {
            // https://github.com/boostorg/rational/blob/boost-1.90.0/include/boost/rational.hpp#L414
            // return identity.Equals(right) ? left : Gcd(right, left % right, identity);
            while (true)
            {
                if (identity.Equals(right))
                    return left;
                (left, right) = (right, policy.Modulus(left, right));
            }
        }
    }
}
