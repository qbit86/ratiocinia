namespace Ratiocinia.Algorithms.Generic
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;

    public static class RationalOperations
    {
        public static (T Numerator, T Denominator) Add<T, TPolicy>(
            T leftNumerator, T leftDenominator, T rightNumerator, T rightDenominator, TPolicy policy)
            where TPolicy :
            IAdditionFunctions<T>,
            IDivisionFunctions<T>,
            IGreatestCommonDivisorFunctions<T>,
            IMultiplyFunctions<T>
        {
            // https://github.com/boostorg/rational/blob/boost-1.90.0/include/boost/rational.hpp#L517
            var gcd = policy.Gcd(leftDenominator, rightDenominator);
            leftDenominator = policy.Divide(leftDenominator, gcd);
            leftNumerator = policy.Add(
                policy.Multiply(leftNumerator, policy.Divide(rightDenominator, gcd)),
                policy.Multiply(rightNumerator, leftDenominator));
            gcd = policy.Gcd(leftNumerator, gcd);
            var numerator = policy.Divide(leftNumerator, gcd);
            var denominator = policy.Multiply(leftDenominator, policy.Divide(rightDenominator, gcd));
            return (numerator, denominator);
        }

        public static (T Numerator, T Denominator) Divide<T, TAdditiveIdentity, TPolicy>(
            T leftNumerator,
            T leftDenominator,
            T rightNumerator,
            T rightDenominator,
            TAdditiveIdentity additiveIdentity,
            TPolicy policy)
            where TAdditiveIdentity : IComparable<T>
            where TPolicy :
            IDivisionFunctions<T>,
            IGreatestCommonDivisorFunctions<T>,
            IMultiplyFunctions<T>,
            IUnaryNegationFunctions<T>
        {
            Debug.Assert(additiveIdentity.CompareTo(leftDenominator) < 0);
            Debug.Assert(additiveIdentity.CompareTo(rightDenominator) < 0);

            // https://github.com/boostorg/rational/blob/boost-1.90.0/include/boost/rational.hpp#L586
            if (additiveIdentity.CompareTo(rightNumerator) is 0)
                throw new ArgumentOutOfRangeException(nameof(rightNumerator));
            if (additiveIdentity.CompareTo(leftNumerator) is 0)
                return (leftNumerator, leftDenominator);

            var gcd1 = policy.Gcd(leftNumerator, rightNumerator);
            var gcd2 = policy.Gcd(leftDenominator, rightDenominator);
            var numerator = policy.Multiply(policy.Divide(leftNumerator, gcd1), policy.Divide(rightDenominator, gcd2));
            var denominator =
                policy.Multiply(policy.Divide(leftDenominator, gcd2), policy.Divide(rightNumerator, gcd1));
            if (additiveIdentity.CompareTo(denominator) > 0)
            {
                numerator = policy.Negate(numerator);
                denominator = policy.Negate(denominator);
            }

            return (numerator, denominator);
        }

        public static (T Numerator, T Denominator) Multiply<T, TPolicy>(
            T leftNumerator, T leftDenominator, T rightNumerator, T rightDenominator, TPolicy policy)
            where TPolicy :
            IDivisionFunctions<T>,
            IGreatestCommonDivisorFunctions<T>,
            IMultiplyFunctions<T>
        {
            // https://github.com/boostorg/rational/blob/boost-1.90.0/include/boost/rational.hpp#L571
            var gcd1 = policy.Gcd(leftNumerator, rightDenominator);
            var gcd2 = policy.Gcd(leftDenominator, rightNumerator);
            var numerator = policy.Multiply(policy.Divide(leftNumerator, gcd1), policy.Divide(rightNumerator, gcd2));
            var denominator =
                policy.Multiply(policy.Divide(leftDenominator, gcd2), policy.Divide(rightDenominator, gcd1));
            return (numerator, denominator);
        }

        public static (T Numerator, T Denominator) Subtract<T, TPolicy>(
            T leftNumerator, T leftDenominator, T rightNumerator, T rightDenominator, TPolicy policy)
            where TPolicy :
            IDivisionFunctions<T>,
            IGreatestCommonDivisorFunctions<T>,
            IMultiplyFunctions<T>,
            ISubtractionFunctions<T>
        {
            // https://github.com/boostorg/rational/blob/boost-1.90.0/include/boost/rational.hpp#L552
            var gcd = policy.Gcd(leftDenominator, rightDenominator);
            leftDenominator = policy.Divide(leftDenominator, gcd);
            leftNumerator = policy.Subtract(
                policy.Multiply(leftNumerator, policy.Divide(rightDenominator, gcd)),
                policy.Multiply(rightNumerator, leftDenominator));
            gcd = policy.Gcd(leftNumerator, gcd);
            var numerator = policy.Divide(leftNumerator, gcd);
            var denominator = policy.Multiply(leftDenominator, policy.Divide(rightDenominator, gcd));
            return (numerator, denominator);
        }

        public static (T Numerator, T Denominator) Negate<T, TPolicy>(T numerator, T denominator, TPolicy policy)
            where TPolicy : IUnaryNegationFunctions<T> =>
            (policy.Negate(numerator), denominator);

        public static (T Numerator, T Denominator) Normalize<T, TAdditiveIdentityComparable, TPolicy>(
            T numerator,
            T denominator,
            T additiveIdentity,
            T multiplicativeIdentity,
            TAdditiveIdentityComparable additiveIdentityComparable,
            TPolicy policy)
            where TAdditiveIdentityComparable : IComparable<T>
            where TPolicy :
            IDivisionFunctions<T>,
            IGreatestCommonDivisorFunctions<T>,
            IUnaryNegationFunctions<T>
        {
            // https://github.com/boostorg/rational/blob/boost-1.90.0/include/boost/rational.hpp#L886
            if (additiveIdentityComparable.CompareTo(denominator) is 0)
                throw new ArgumentOutOfRangeException(nameof(denominator));

            if (additiveIdentityComparable.CompareTo(numerator) is 0)
                return (additiveIdentity, multiplicativeIdentity);

            var gcd = policy.Gcd(numerator, denominator);
            numerator = policy.Divide(numerator, gcd);
            denominator = policy.Divide(denominator, gcd);

            if (additiveIdentityComparable.CompareTo(denominator) > 0)
            {
                numerator = policy.Negate(numerator);
                denominator = policy.Negate(denominator);
            }

            return (numerator, denominator);
        }

        public static bool IsNormalized<T, TAdditiveIdentity, TMultiplicativeIdentity, TPolicy>(
            T numerator,
            T denominator,
            TAdditiveIdentity additiveIdentity,
            TMultiplicativeIdentity multiplicativeIdentity,
            TPolicy policy)
            where TAdditiveIdentity : IComparable<T>
            where TMultiplicativeIdentity : IEquatable<T>
            where TPolicy : IAbsoluteFunctions<T>, IGreatestCommonDivisorFunctions<T>
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

        public static bool LessThan<T, TPolicy>(
            T leftNumerator,
            T leftDenominator,
            T rightNumerator,
            T rightDenominator,
            T additiveIdentity,
            TPolicy policy)
            where TPolicy :
            IAdditionFunctions<T>,
            IComparer<T>,
            IDecrementFunctions<T>,
            IDivisionFunctions<T>,
            IModulusFunctions<T>
        {
            // https://github.com/boostorg/rational/blob/boost-1.90.0/include/boost/rational.hpp#L785
            // Uses continued fraction expansion via Euclidean algorithm to avoid overflow
            // that would occur with direct cross-multiplication comparison.

            Debug.Assert(policy.Compare(additiveIdentity, leftDenominator) < 0);
            Debug.Assert(policy.Compare(additiveIdentity, rightDenominator) < 0);

            // Initialize continued fraction state for both operands
            ContinuedFractionState<T> left = new(
                leftDenominator,
                policy.Divide(leftNumerator, leftDenominator),
                policy.Modulus(leftNumerator, leftDenominator));

            ContinuedFractionState<T> right = new(
                rightDenominator,
                policy.Divide(rightNumerator, rightDenominator),
                policy.Modulus(rightNumerator, rightDenominator));

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
                left = new ContinuedFractionState<T>(
                    left.Remainder,
                    policy.Divide(left.Denominator, left.Remainder),
                    policy.Modulus(left.Denominator, left.Remainder));

                right = new ContinuedFractionState<T>(
                    right.Remainder,
                    policy.Divide(right.Denominator, right.Remainder),
                    policy.Modulus(right.Denominator, right.Remainder));
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
