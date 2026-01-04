namespace Ratiocinia.Models
{
    using System;
    using System.Numerics;
    using System.Runtime.CompilerServices;

    internal static class IntegerOperations
    {
        internal static T GcdEquatable<T>(T left, T right)
            where T : IAdditiveIdentity<T, T>, IEquatable<T>, IModulusOperators<T, T, T> =>
            Gcd(left, right, T.AdditiveIdentity);

        internal static T GcdComparable<T>(T left, T right)
            where T : IAdditiveIdentity<T, T>, IComparable<T>, IModulusOperators<T, T, T>
        {
            ComparableEquatable<T> identity = new(T.AdditiveIdentity);
            return Gcd(left, right, identity);
        }

        private static T Gcd<T, TEquatable>(T left, T right, TEquatable identity)
            where T : IModulusOperators<T, T, T>
#if NET9_0_OR_GREATER
            where TEquatable : IEquatable<T>, allows ref struct
#else
            where TEquatable : IEquatable<T>
#endif
        {
            // https://github.com/boostorg/rational/blob/boost-1.90.0/include/boost/rational.hpp#L414
            // return identity.Equals(right) ? left : Gcd(right, left % right, identity);
            while (true)
            {
                if (identity.Equals(right))
                    return left;
                (left, right) = (right, left % right);
            }
        }
    }

#if NET9_0_OR_GREATER
    file readonly ref struct ComparableEquatable<T>(T comparable) : IEquatable<T>
#else
    file readonly struct ComparableEquatable<T>(T comparable) : IEquatable<T>
#endif
        where T : IComparable<T>
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool Equals(T? other) => comparable.CompareTo(other) is 0;
    }
}
