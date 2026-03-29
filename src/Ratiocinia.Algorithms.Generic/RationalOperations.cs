namespace Ratiocinia.Algorithms.Generic
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using MathFoundations;

    /// <summary>
    /// Provides generic arithmetic operations for rational numbers represented as numerator/denominator pairs.
    /// </summary>
    /// <remarks>
    /// All operations assume input rational numbers are in normalized form
    /// (positive denominator, reduced to the lowest terms) unless otherwise noted.
    /// Results are returned in normalized form.
    /// </remarks>
    public static class RationalOperations
    {
        /// <summary>
        /// Adds two rational numbers.
        /// </summary>
        /// <typeparam name="T">The type of the numerator and denominator values.</typeparam>
        /// <typeparam name="TPolicy">The policy type providing arithmetic operations.</typeparam>
        /// <param name="leftNumerator">The numerator of the first rational number.</param>
        /// <param name="leftDenominator">The denominator of the first rational number.</param>
        /// <param name="rightNumerator">The numerator of the second rational number.</param>
        /// <param name="rightDenominator">The denominator of the second rational number.</param>
        /// <param name="policy">The policy providing arithmetic operations.</param>
        /// <returns>A tuple containing the numerator and denominator of the sum in reduced form.</returns>
        public static (T Numerator, T Denominator) Add<T, TPolicy>(
            T leftNumerator, T leftDenominator, T rightNumerator, T rightDenominator, TPolicy policy)
            where TPolicy :
            IAdd<T>,
            IDivideTruncated<T>,
            IGcd<T>,
            IMultiply<T>
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

        /// <summary>
        /// Divides two rational numbers.
        /// </summary>
        /// <typeparam name="T">The type of the numerator and denominator values.</typeparam>
        /// <typeparam name="TAdditiveIdentity">The type representing the additive identity (zero), which must be comparable to <typeparamref name="T" />.</typeparam>
        /// <typeparam name="TPolicy">The policy type providing arithmetic operations.</typeparam>
        /// <param name="leftNumerator">The numerator of the dividend.</param>
        /// <param name="leftDenominator">The denominator of the dividend.</param>
        /// <param name="rightNumerator">The numerator of the divisor.</param>
        /// <param name="rightDenominator">The denominator of the divisor.</param>
        /// <param name="additiveIdentity">The additive identity (zero) used for sign normalization.</param>
        /// <param name="policy">The policy providing arithmetic operations.</param>
        /// <returns>A tuple containing the numerator and denominator of the quotient in reduced form.</returns>
        /// <exception cref="ArgumentOutOfRangeException">Thrown when the divisor is zero (<paramref name="rightNumerator" /> is zero).</exception>
        public static (T Numerator, T Denominator) Divide<T, TAdditiveIdentity, TPolicy>(
            T leftNumerator,
            T leftDenominator,
            T rightNumerator,
            T rightDenominator,
            TAdditiveIdentity additiveIdentity,
            TPolicy policy)
            where TAdditiveIdentity : IComparable<T>
            where TPolicy :
            IDivideTruncated<T>,
            IGcd<T>,
            IMultiply<T>,
            INegate<T>
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

        /// <summary>
        /// Multiplies two rational numbers.
        /// </summary>
        /// <typeparam name="T">The type of the numerator and denominator values.</typeparam>
        /// <typeparam name="TPolicy">The policy type providing arithmetic operations.</typeparam>
        /// <param name="leftNumerator">The numerator of the first rational number.</param>
        /// <param name="leftDenominator">The denominator of the first rational number.</param>
        /// <param name="rightNumerator">The numerator of the second rational number.</param>
        /// <param name="rightDenominator">The denominator of the second rational number.</param>
        /// <param name="policy">The policy providing arithmetic operations.</param>
        /// <returns>A tuple containing the numerator and denominator of the product in reduced form.</returns>
        public static (T Numerator, T Denominator) Multiply<T, TPolicy>(
            T leftNumerator, T leftDenominator, T rightNumerator, T rightDenominator, TPolicy policy)
            where TPolicy :
            IDivideTruncated<T>,
            IGcd<T>,
            IMultiply<T>
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

        /// <summary>
        /// Subtracts two rational numbers.
        /// </summary>
        /// <typeparam name="T">The type of the numerator and denominator values.</typeparam>
        /// <typeparam name="TPolicy">The policy type providing arithmetic operations.</typeparam>
        /// <param name="leftNumerator">The numerator of the minuend.</param>
        /// <param name="leftDenominator">The denominator of the minuend.</param>
        /// <param name="rightNumerator">The numerator of the subtrahend.</param>
        /// <param name="rightDenominator">The denominator of the subtrahend.</param>
        /// <param name="policy">The policy providing arithmetic operations.</param>
        /// <returns>A tuple containing the numerator and denominator of the difference in reduced form.</returns>
        public static (T Numerator, T Denominator) Subtract<T, TPolicy>(
            T leftNumerator, T leftDenominator, T rightNumerator, T rightDenominator, TPolicy policy)
            where TPolicy :
            IDivideTruncated<T>,
            IGcd<T>,
            IMultiply<T>,
            ISubtract<T>
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

        /// <summary>
        /// Negates a rational number.
        /// </summary>
        /// <typeparam name="T">The type of the numerator and denominator values.</typeparam>
        /// <typeparam name="TPolicy">The policy type providing the unary negation operation.</typeparam>
        /// <param name="numerator">The numerator of the rational number to negate.</param>
        /// <param name="denominator">The denominator of the rational number to negate.</param>
        /// <param name="policy">The policy providing the negation operation.</param>
        /// <returns>A tuple containing the numerator and denominator of the negated rational number.</returns>
        public static (T Numerator, T Denominator) Negate<T, TPolicy>(T numerator, T denominator, TPolicy policy)
            where TPolicy : INegate<T> =>
            (policy.Negate(numerator), denominator);

        /// <summary>
        /// Computes the reciprocal (multiplicative inverse) of a rational number.
        /// </summary>
        /// <typeparam name="T">The type of the numerator and denominator values.</typeparam>
        /// <typeparam name="TAdditiveIdentity">The type representing the additive identity (zero), which must be comparable to <typeparamref name="T" />.</typeparam>
        /// <typeparam name="TPolicy">The policy type providing the unary negation operation.</typeparam>
        /// <param name="numerator">The numerator of the rational number.</param>
        /// <param name="denominator">The denominator of the rational number.</param>
        /// <param name="additiveIdentity">The additive identity (zero) used for comparisons.</param>
        /// <param name="policy">The policy providing the negation operation.</param>
        /// <returns>A tuple containing the numerator and denominator of the reciprocal in normalized form.</returns>
        /// <exception cref="ArgumentOutOfRangeException">Thrown when <paramref name="numerator" /> is zero.</exception>
        public static (T Numerator, T Denominator) Reciprocal<T, TAdditiveIdentity, TPolicy>(
            T numerator,
            T denominator,
            TAdditiveIdentity additiveIdentity,
            TPolicy policy)
            where TAdditiveIdentity : IComparable<T>
            where TPolicy : INegate<T>
        {
            Debug.Assert(additiveIdentity.CompareTo(denominator) < 0);

            if (additiveIdentity.CompareTo(numerator) is 0)
                throw new ArgumentOutOfRangeException(nameof(numerator));

            if (additiveIdentity.CompareTo(numerator) > 0)
                return (policy.Negate(denominator), policy.Negate(numerator));

            return (denominator, numerator);
        }

        /// <summary>
        /// Normalizes a rational number to its canonical form.
        /// </summary>
        /// <typeparam name="T">The type of the numerator and denominator values.</typeparam>
        /// <typeparam name="TAdditiveIdentityComparable">The type representing the additive identity (zero), which must be comparable to <typeparamref name="T" />.</typeparam>
        /// <typeparam name="TPolicy">The policy type providing arithmetic operations.</typeparam>
        /// <param name="numerator">The numerator of the rational number to normalize.</param>
        /// <param name="denominator">The denominator of the rational number to normalize.</param>
        /// <param name="additiveIdentity">The additive identity (zero) value.</param>
        /// <param name="multiplicativeIdentity">The multiplicative identity (one) value.</param>
        /// <param name="additiveIdentityComparable">The additive identity used for comparisons.</param>
        /// <param name="policy">The policy providing arithmetic operations.</param>
        /// <returns>A tuple containing the normalized numerator and denominator, reduced to the lowest terms with a positive denominator.</returns>
        /// <exception cref="ArgumentOutOfRangeException">Thrown when <paramref name="denominator" /> is zero.</exception>
        /// <remarks>
        /// Normalization ensures:
        /// <list type="bullet">
        /// <item>
        /// <description>The denominator is always positive.</description>
        /// </item>
        /// <item>
        /// <description>The numerator and denominator are reduced to the lowest terms (GCD is 1).</description>
        /// </item>
        /// <item>
        /// <description>Zero is represented as 0/1.</description>
        /// </item>
        /// </list>
        /// </remarks>
        public static (T Numerator, T Denominator) Normalize<T, TAdditiveIdentityComparable, TPolicy>(
            T numerator,
            T denominator,
            T additiveIdentity,
            T multiplicativeIdentity,
            TAdditiveIdentityComparable additiveIdentityComparable,
            TPolicy policy)
            where TAdditiveIdentityComparable : IComparable<T>
            where TPolicy :
            IDivideTruncated<T>,
            IGcd<T>,
            INegate<T>
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

        /// <summary>
        /// Determines whether a rational number is in normalized (canonical) form.
        /// </summary>
        /// <typeparam name="T">The type of the numerator and denominator values.</typeparam>
        /// <typeparam name="TAdditiveIdentity">The type representing the additive identity (zero), which must be comparable to <typeparamref name="T" />.</typeparam>
        /// <typeparam name="TMultiplicativeIdentity">The type representing the multiplicative identity (one), which must be equatable to <typeparamref name="T" />.</typeparam>
        /// <typeparam name="TPolicy">The policy type providing arithmetic operations.</typeparam>
        /// <param name="numerator">The numerator of the rational number to check.</param>
        /// <param name="denominator">The denominator of the rational number to check.</param>
        /// <param name="additiveIdentity">The additive identity (zero) used for comparisons.</param>
        /// <param name="multiplicativeIdentity">The multiplicative identity (one) used for comparisons.</param>
        /// <param name="policy">The policy providing arithmetic operations.</param>
        /// <returns>
        /// <see langword="true" /> if the rational number is normalized; otherwise, <see langword="false" />.
        /// </returns>
        /// <remarks>
        /// A rational number is considered normalized if:
        /// <list type="bullet">
        /// <item>
        /// <description>The denominator is positive.</description>
        /// </item>
        /// <item>
        /// <description>The numerator and denominator are coprime (GCD is 1).</description>
        /// </item>
        /// <item>
        /// <description>If the numerator is zero, the denominator must be 1.</description>
        /// </item>
        /// </list>
        /// </remarks>
        public static bool IsNormalized<T, TAdditiveIdentity, TMultiplicativeIdentity, TPolicy>(
            T numerator,
            T denominator,
            TAdditiveIdentity additiveIdentity,
            TMultiplicativeIdentity multiplicativeIdentity,
            TPolicy policy)
            where TAdditiveIdentity : IComparable<T>
            where TMultiplicativeIdentity : IEquatable<T>
            where TPolicy : IAbs<T>, IGcd<T>
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

        /// <summary>
        /// Determines whether one rational number is less than another.
        /// </summary>
        /// <typeparam name="T">The type of the numerator and denominator values.</typeparam>
        /// <typeparam name="TPolicy">The policy type providing arithmetic and comparison operations.</typeparam>
        /// <param name="leftNumerator">The numerator of the first rational number.</param>
        /// <param name="leftDenominator">The denominator of the first rational number.</param>
        /// <param name="rightNumerator">The numerator of the second rational number.</param>
        /// <param name="rightDenominator">The denominator of the second rational number.</param>
        /// <param name="additiveIdentity">The additive identity (zero) used for comparisons.</param>
        /// <param name="policy">The policy providing arithmetic and comparison operations.</param>
        /// <returns>
        /// <see langword="true" /> if the first rational number is less than the second; otherwise, <see langword="false" />.
        /// </returns>
        /// <remarks>
        /// This method uses continued fraction expansion via the Euclidean algorithm to compare
        /// rational numbers without overflow that would occur with direct cross-multiplication.
        /// Both input rational numbers must have positive denominators.
        /// </remarks>
        public static bool LessThan<T, TPolicy>(
            T leftNumerator,
            T leftDenominator,
            T rightNumerator,
            T rightDenominator,
            T additiveIdentity,
            TPolicy policy)
            where TPolicy :
            IAdd<T>,
            IComparer<T>,
            IDecrement<T>,
            IDivRemTruncated<T>
        {
            // https://github.com/boostorg/rational/blob/boost-1.90.0/include/boost/rational.hpp#L785
            // Uses continued fraction expansion via Euclidean algorithm to avoid overflow
            // that would occur with direct cross-multiplication comparison.

            Debug.Assert(policy.Compare(additiveIdentity, leftDenominator) < 0);
            Debug.Assert(policy.Compare(additiveIdentity, rightDenominator) < 0);

            // Initialize continued fraction state for both operands

            var (leftQuotient, leftRemainder) = policy.DivRemTruncated(leftNumerator, leftDenominator);
            ContinuedFractionState<T> left = new(leftDenominator, leftQuotient, leftRemainder);

            var (rightQuotient, rightRemainder) = policy.DivRemTruncated(rightNumerator, rightDenominator);
            ContinuedFractionState<T> right = new(rightDenominator, rightQuotient, rightRemainder);

            // Tracks whether a comparison direction should be reversed.
            // Each iteration effectively computes reciprocals, flipping the comparison sense.
            bool reverseComparison = false;

            // Normalize negative remainders to ensure a consistent comparison.
            // For negative numerators, modulus may yield negative remainders.
            while (policy.Compare(left.Remainder, additiveIdentity) < 0)
            {
                left = left with
                {
                    Quotient = policy.Decrement(left.Quotient),
                    Remainder = policy.Add(left.Remainder, left.Denominator)
                };
            }

            while (policy.Compare(right.Remainder, additiveIdentity) < 0)
            {
                right = right with
                {
                    Quotient = policy.Decrement(right.Quotient),
                    Remainder = policy.Add(right.Remainder, right.Denominator)
                };
            }

            // Compare continued fraction components iteratively
            while (true)
            {
                int quotientComparison = policy.Compare(left.Quotient, right.Quotient);
                if (quotientComparison != 0)
                {
                    // Quotients differ - comparison result depends on reversal state
                    return reverseComparison
                        ? quotientComparison > 0
                        : quotientComparison < 0;
                }

                // Quotients are equal - flip comparison direction for next iteration
                reverseComparison = !reverseComparison;

                // If either remainder is zero, one fraction terminates
                bool leftRemainderIsZero = policy.Compare(left.Remainder, additiveIdentity) is 0;
                bool rightRemainderIsZero = policy.Compare(right.Remainder, additiveIdentity) is 0;
                if (leftRemainderIsZero || rightRemainderIsZero)
                {
                    // At least one continued fraction expansion has ended.
                    // Boost logic:
                    // - If both ended here, the values are equal => false
                    // - Otherwise, the one that still has terms is smaller/larger depending on parity (reverseComparison)
                    if (leftRemainderIsZero && rightRemainderIsZero)
                        return false;

                    return !leftRemainderIsZero != reverseComparison;
                }

                // Advance to the next continued fraction term: swap numerator with denominator,
                // and denominator with the remainder (Euclidean algorithm step)
                var (nextLeftQuotient, nextLeftRemainder) = policy.DivRemTruncated(left.Denominator, left.Remainder);
                left = new ContinuedFractionState<T>(left.Remainder, nextLeftQuotient, nextLeftRemainder);

                var (nextRightQuotient, nextRightRemainder) = policy.DivRemTruncated(right.Denominator, right.Remainder);
                right = new ContinuedFractionState<T>(right.Remainder, nextRightQuotient, nextRightRemainder);
            }
        }
    }

    /// <summary>
    /// Represents the state of a continued fraction expansion during rational comparison.
    /// Used by the Euclidean algorithm to iteratively decompose fractions.
    /// </summary>
    /// <typeparam name="T">The integer type used for numerator and denominator.</typeparam>
    /// <param name="Denominator">
    /// Current denominator in the Euclidean algorithm step. (The current numerator is always the previous step's denominator.)
    /// </param>
    /// <param name="Quotient">Integer part of the current fraction (Numerator / Denominator).</param>
    /// <param name="Remainder">Fractional part remainder (Numerator % Denominator).</param>
    file readonly record struct ContinuedFractionState<T>(
        T Denominator,
        T Quotient,
        T Remainder);
}
