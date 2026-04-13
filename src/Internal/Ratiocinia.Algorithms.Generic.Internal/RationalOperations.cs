namespace Ratiocinia.Algorithms.Generic.Internal
{
    using System;
    using System.Diagnostics;
    using MathFoundations;

    internal static class RationalOperations
    {
        internal static (T Numerator, T Denominator) Add<T, TPolicy>(
            T leftNumerator, T leftDenominator, T rightNumerator, T rightDenominator, TPolicy policy)
#if NET9_0_OR_GREATER
            where TPolicy : IAdd<T>, IDivideTruncated<T>, IGcd<T>, IMultiply<T>, allows ref struct
#else
            where TPolicy : IAdd<T>, IDivideTruncated<T>, IGcd<T>, IMultiply<T>
#endif
        {
            // https://github.com/boostorg/rational/blob/boost-1.90.0/include/boost/rational.hpp#L517
            var gcd = policy.Gcd(leftDenominator, rightDenominator);
            leftDenominator = policy.DivideTruncated(leftDenominator, gcd);
            leftNumerator = policy.Add(
                policy.Multiply(leftNumerator, policy.DivideTruncated(rightDenominator, gcd)),
                policy.Multiply(rightNumerator, leftDenominator));
            gcd = policy.Gcd(leftNumerator, gcd);
            var numerator = policy.DivideTruncated(leftNumerator, gcd);
            var denominator = policy.Multiply(leftDenominator, policy.DivideTruncated(rightDenominator, gcd));
            return (numerator, denominator);
        }

        internal static (T Numerator, T Denominator) Divide<T, TAdditiveIdentity, TPolicy>(
            T leftNumerator, T leftDenominator, T rightNumerator, T rightDenominator,
            TAdditiveIdentity additiveIdentity, TPolicy policy)
#if NET9_0_OR_GREATER
            where TAdditiveIdentity : IComparable<T>, allows ref struct
            where TPolicy : IDivideTruncated<T>, IGcd<T>, IMultiply<T>, INegate<T>, allows ref struct
#else
            where TAdditiveIdentity : IComparable<T>
            where TPolicy : IDivideTruncated<T>, IGcd<T>, IMultiply<T>, INegate<T>
#endif
        {
            Debug.Assert(additiveIdentity.CompareTo(leftDenominator) < 0);
            Debug.Assert(additiveIdentity.CompareTo(rightDenominator) < 0);

            // https://github.com/boostorg/rational/blob/boost-1.90.0/include/boost/rational.hpp#L586
            if (additiveIdentity.CompareTo(rightNumerator) is 0)
                throw new ArgumentOutOfRangeException(nameof(rightNumerator));
            if (additiveIdentity.CompareTo(leftNumerator) is 0)
                return (leftNumerator, leftDenominator);

            var gcd1 = policy.Gcd(leftNumerator, rightNumerator);
            var gcd2 = policy.Gcd(rightDenominator, leftDenominator);
            var numerator = policy.Multiply(
                policy.DivideTruncated(leftNumerator, gcd1), policy.DivideTruncated(rightDenominator, gcd2));
            var denominator = policy.Multiply(
                policy.DivideTruncated(leftDenominator, gcd2), policy.DivideTruncated(rightNumerator, gcd1));
            if (additiveIdentity.CompareTo(denominator) > 0)
            {
                numerator = policy.Negate(numerator);
                denominator = policy.Negate(denominator);
            }

            return (numerator, denominator);
        }

        internal static (T Numerator, T Denominator) Multiply<T, TPolicy>(
            T leftNumerator, T leftDenominator, T rightNumerator, T rightDenominator, TPolicy policy)
#if NET9_0_OR_GREATER
            where TPolicy : IDivideTruncated<T>, IGcd<T>, IMultiply<T>, allows ref struct
#else
            where TPolicy : IDivideTruncated<T>, IGcd<T>, IMultiply<T>
#endif
        {
            // https://github.com/boostorg/rational/blob/boost-1.90.0/include/boost/rational.hpp#L571
            var gcd1 = policy.Gcd(leftNumerator, rightDenominator);
            var gcd2 = policy.Gcd(rightNumerator, leftDenominator);
            var numerator = policy.Multiply(
                policy.DivideTruncated(leftNumerator, gcd1), policy.DivideTruncated(rightNumerator, gcd2));
            var denominator = policy.Multiply(
                policy.DivideTruncated(leftDenominator, gcd2), policy.DivideTruncated(rightDenominator, gcd1));
            return (numerator, denominator);
        }

        internal static (T Numerator, T Denominator) Subtract<T, TPolicy>(
            T leftNumerator, T leftDenominator, T rightNumerator, T rightDenominator, TPolicy policy)
#if NET9_0_OR_GREATER
            where TPolicy : IDivideTruncated<T>, IGcd<T>, IMultiply<T>, ISubtract<T>, allows ref struct
#else
            where TPolicy : IDivideTruncated<T>, IGcd<T>, IMultiply<T>, ISubtract<T>
#endif
        {
            // https://github.com/boostorg/rational/blob/boost-1.90.0/include/boost/rational.hpp#L552
            var gcd = policy.Gcd(leftDenominator, rightDenominator);
            leftDenominator = policy.DivideTruncated(leftDenominator, gcd);
            leftNumerator = policy.Subtract(
                policy.Multiply(leftNumerator, policy.DivideTruncated(rightDenominator, gcd)),
                policy.Multiply(rightNumerator, leftDenominator));
            gcd = policy.Gcd(leftNumerator, gcd);
            var numerator = policy.DivideTruncated(leftNumerator, gcd);
            var denominator = policy.Multiply(leftDenominator, policy.DivideTruncated(rightDenominator, gcd));
            return (numerator, denominator);
        }

        internal static (T Numerator, T Denominator) Negate<T, TPolicy>(T numerator, T denominator, TPolicy policy)
#if NET9_0_OR_GREATER
            where TPolicy : INegate<T>, allows ref struct
#else
            where TPolicy : INegate<T>
#endif
            => (policy.Negate(numerator), denominator);

        internal static (T Numerator, T Denominator) Reciprocal<T, TAdditiveIdentity, TPolicy>(
            T numerator, T denominator, TAdditiveIdentity additiveIdentity, TPolicy policy)
#if NET9_0_OR_GREATER
            where TAdditiveIdentity : IComparable<T>, allows ref struct
            where TPolicy : INegate<T>, allows ref struct
#else
            where TAdditiveIdentity : IComparable<T>
            where TPolicy : INegate<T>
#endif
        {
            Debug.Assert(additiveIdentity.CompareTo(denominator) < 0);

            if (additiveIdentity.CompareTo(numerator) is 0)
                throw new ArgumentOutOfRangeException(nameof(numerator));

            if (additiveIdentity.CompareTo(numerator) > 0)
                return (policy.Negate(denominator), policy.Negate(numerator));

            return (denominator, numerator);
        }

        internal static (T Numerator, T Denominator) Normalize<T, TAdditiveIdentityComparable, TPolicy>(
            T numerator,
            T denominator,
            T additiveIdentity,
            T multiplicativeIdentity,
            TAdditiveIdentityComparable additiveIdentityComparable,
            TPolicy policy)
#if NET9_0_OR_GREATER
            where TAdditiveIdentityComparable : IComparable<T>, allows ref struct
            where TPolicy : IDivideTruncated<T>, IGcd<T>, INegate<T>, allows ref struct
#else
            where TAdditiveIdentityComparable : IComparable<T>
            where TPolicy : IDivideTruncated<T>, IGcd<T>, INegate<T>
#endif
        {
            // https://github.com/boostorg/rational/blob/boost-1.90.0/include/boost/rational.hpp#L886
            if (additiveIdentityComparable.CompareTo(denominator) is 0)
                throw new ArgumentOutOfRangeException(nameof(denominator));

            if (additiveIdentityComparable.CompareTo(numerator) is 0)
                return (additiveIdentity, multiplicativeIdentity);

            var gcd = policy.Gcd(numerator, denominator);
            numerator = policy.DivideTruncated(numerator, gcd);
            denominator = policy.DivideTruncated(denominator, gcd);

            if (additiveIdentityComparable.CompareTo(denominator) > 0)
            {
                numerator = policy.Negate(numerator);
                denominator = policy.Negate(denominator);
            }

            return (numerator, denominator);
        }

        internal static bool IsNormalized<T, TAdditiveIdentity, TMultiplicativeIdentity, TPolicy>(
            T numerator,
            T denominator,
            TAdditiveIdentity additiveIdentity,
            TMultiplicativeIdentity multiplicativeIdentity,
            TPolicy policy)
#if NET9_0_OR_GREATER
            where TAdditiveIdentity : IComparable<T>, allows ref struct
            where TMultiplicativeIdentity : IEquatable<T>, allows ref struct
            where TPolicy : IAbs<T>, IGcd<T>, allows ref struct
#else
            where TAdditiveIdentity : IComparable<T>
            where TMultiplicativeIdentity : IEquatable<T>
            where TPolicy : IAbs<T>, IGcd<T>
#endif
        {
            // https://github.com/boostorg/rational/blob/boost-1.90.0/include/boost/rational.hpp#L430
            if (additiveIdentity.CompareTo(denominator) >= 0)
                return false;

            if (additiveIdentity.CompareTo(numerator) is 0 && !multiplicativeIdentity.Equals(denominator))
                return false;

            var gcd = policy.Gcd(numerator, denominator);
            var abs = policy.Abs(gcd);
            return multiplicativeIdentity.Equals(abs);
        }
    }
}
