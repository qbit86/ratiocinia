namespace Ratiocinia.Algorithms.Generic
{
    using System;

    public static class GreatestCommonDivisor
    {
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
