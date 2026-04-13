namespace Ratiocinia.Algorithms.Generic.Internal
{
    using MathFoundations;

    internal static class GreatestCommonDivisor
    {
        internal static T Gcd<T, TPolicy>(T left, T right, TPolicy policy)
#if NET9_0_OR_GREATER
            where TPolicy : IAbs<T>, IRemainderTruncated<T>, IIsAdditiveIdentity<T>, allows ref struct
#else
            where TPolicy : IAbs<T>, IRemainderTruncated<T>, IIsAdditiveIdentity<T>
#endif
            => GcdUnchecked(policy.Abs(left), policy.Abs(right), policy);

        internal static T GcdUnchecked<T, TPolicy>(T left, T right, TPolicy policy)
#if NET9_0_OR_GREATER
            where TPolicy : IRemainderTruncated<T>, IIsAdditiveIdentity<T>, allows ref struct
#else
            where TPolicy : IRemainderTruncated<T>, IIsAdditiveIdentity<T>
#endif
        {
            // https://github.com/boostorg/rational/blob/boost-1.90.0/include/boost/rational.hpp#L414
            // return identity.Equals(right) ? left : Gcd(right, left % right, identity);
            while (true)
            {
                if (policy.IsAdditiveIdentity(right))
                    return left;
                (left, right) = (right, policy.RemainderTruncated(left, right));
            }
        }
    }
}
