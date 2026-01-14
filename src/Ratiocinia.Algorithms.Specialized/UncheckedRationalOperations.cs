namespace Ratiocinia.Algorithms.Specialized
{
    using System;
    using System.Numerics;
    using Generic;
    using Models;

    /// <summary>
    /// Provides arithmetic operations for rational numbers without overflow checking.
    /// </summary>
    /// <remarks>
    /// Operations in this class do not throw exceptions on arithmetic overflow. Instead, they wrap around silently.
    /// </remarks>
    public static class UncheckedRationalOperations
    {
        /// <summary>
        /// Adds two rational numbers without overflow checking.
        /// </summary>
        /// <typeparam name="T">The numeric type of the numerator and denominator.</typeparam>
        /// <param name="leftNumerator">The numerator of the first rational number.</param>
        /// <param name="leftDenominator">The denominator of the first rational number.</param>
        /// <param name="rightNumerator">The numerator of the second rational number.</param>
        /// <param name="rightDenominator">The denominator of the second rational number.</param>
        /// <returns>A tuple containing the numerator and denominator of the sum in normalized form.</returns>
        public static (T Numerator, T Denominator) Add<T>(
            T leftNumerator, T leftDenominator, T rightNumerator, T rightDenominator)
            where T :
            IAdditionOperators<T, T, T>,
            IAdditiveIdentity<T, T>,
            IDivisionOperators<T, T, T>,
            IEquatable<T>,
            IModulusOperators<T, T, T>,
            IMultiplyOperators<T, T, T> =>
            RationalOperations.Add(
                leftNumerator, leftDenominator, rightNumerator, rightDenominator,
                UncheckedAdditionPolicy<T>.Instance);

        /// <summary>
        /// Divides one rational number by another without overflow checking.
        /// </summary>
        /// <typeparam name="T">The numeric type of the numerator and denominator.</typeparam>
        /// <param name="leftNumerator">The numerator of the dividend.</param>
        /// <param name="leftDenominator">The denominator of the dividend.</param>
        /// <param name="rightNumerator">The numerator of the divisor.</param>
        /// <param name="rightDenominator">The denominator of the divisor.</param>
        /// <returns>A tuple containing the numerator and denominator of the quotient in normalized form.</returns>
        public static (T Numerator, T Denominator) Divide<T>(
            T leftNumerator, T leftDenominator, T rightNumerator, T rightDenominator)
            where T :
            IAdditiveIdentity<T, T>,
            IDivisionOperators<T, T, T>,
            IComparable<T>,
            IModulusOperators<T, T, T>,
            IMultiplyOperators<T, T, T>,
            IUnaryNegationOperators<T, T> =>
            RationalOperations.Divide(
                leftNumerator, leftDenominator, rightNumerator, rightDenominator,
                T.AdditiveIdentity,
                UncheckedDivisionPolicy<T>.Instance);

        /// <summary>
        /// Multiplies two rational numbers without overflow checking.
        /// </summary>
        /// <typeparam name="T">The numeric type of the numerator and denominator.</typeparam>
        /// <param name="leftNumerator">The numerator of the first rational number.</param>
        /// <param name="leftDenominator">The denominator of the first rational number.</param>
        /// <param name="rightNumerator">The numerator of the second rational number.</param>
        /// <param name="rightDenominator">The denominator of the second rational number.</param>
        /// <returns>A tuple containing the numerator and denominator of the product in normalized form.</returns>
        public static (T Numerator, T Denominator) Multiply<T>(
            T leftNumerator, T leftDenominator, T rightNumerator, T rightDenominator)
            where T :
            IAdditiveIdentity<T, T>,
            IDivisionOperators<T, T, T>,
            IEquatable<T>,
            IModulusOperators<T, T, T>,
            IMultiplyOperators<T, T, T> =>
            RationalOperations.Multiply(
                leftNumerator, leftDenominator, rightNumerator, rightDenominator,
                UncheckedMultiplyPolicy<T>.Instance);

        /// <summary>
        /// Subtracts one rational number from another without overflow checking.
        /// </summary>
        /// <typeparam name="T">The numeric type of the numerator and denominator.</typeparam>
        /// <param name="leftNumerator">The numerator of the minuend.</param>
        /// <param name="leftDenominator">The denominator of the minuend.</param>
        /// <param name="rightNumerator">The numerator of the subtrahend.</param>
        /// <param name="rightDenominator">The denominator of the subtrahend.</param>
        /// <returns>A tuple containing the numerator and denominator of the difference in normalized form.</returns>
        public static (T Numerator, T Denominator) Subtract<T>(
            T leftNumerator, T leftDenominator, T rightNumerator, T rightDenominator)
            where T :
            IAdditiveIdentity<T, T>,
            IDivisionOperators<T, T, T>,
            IEquatable<T>,
            IModulusOperators<T, T, T>,
            IMultiplyOperators<T, T, T>,
            ISubtractionOperators<T, T, T> =>
            RationalOperations.Subtract(
                leftNumerator, leftDenominator, rightNumerator, rightDenominator,
                UncheckedSubtractionPolicy<T>.Instance);

        /// <summary>
        /// Negates a rational number without overflow checking.
        /// </summary>
        /// <typeparam name="T">The numeric type of the numerator and denominator.</typeparam>
        /// <param name="numerator">The numerator of the rational number.</param>
        /// <param name="denominator">The denominator of the rational number.</param>
        /// <returns>A tuple containing the numerator and denominator of the negated rational number.</returns>
        public static (T Numerator, T Denominator) Negate<T>(T numerator, T denominator)
            where T : IUnaryNegationOperators<T, T> =>
            RationalOperations.Negate(numerator, denominator, UncheckedUnaryNegationPolicy<T>.Instance);

        /// <summary>
        /// Normalizes a rational number by reducing it to lowest terms and ensuring the denominator is positive, without overflow checking.
        /// </summary>
        /// <typeparam name="T">The numeric type of the numerator and denominator.</typeparam>
        /// <param name="numerator">The numerator of the rational number.</param>
        /// <param name="denominator">The denominator of the rational number.</param>
        /// <returns>A tuple containing the numerator and denominator in normalized form.</returns>
        public static (T Numerator, T Denominator) Normalize<T>(T numerator, T denominator)
            where T :
            IAdditiveIdentity<T, T>,
            IDivisionOperators<T, T, T>,
            IComparable<T>,
            IModulusOperators<T, T, T>,
            IMultiplicativeIdentity<T, T>,
            IUnaryNegationOperators<T, T> =>
            RationalOperations.Normalize(
                numerator,
                denominator,
                T.AdditiveIdentity,
                T.MultiplicativeIdentity,
                T.AdditiveIdentity,
                UncheckedNormalizePolicy<T>.Instance);

        /// <summary>
        /// Determines whether one rational number is less than another, without overflow checking.
        /// </summary>
        /// <typeparam name="T">The numeric type of the numerator and denominator.</typeparam>
        /// <param name="leftNumerator">The numerator of the first rational number.</param>
        /// <param name="leftDenominator">The denominator of the first rational number.</param>
        /// <param name="rightNumerator">The numerator of the second rational number.</param>
        /// <param name="rightDenominator">The denominator of the second rational number.</param>
        /// <returns><see langword="true" /> if the first rational number is less than the second; otherwise, <see langword="false" />.</returns>
        public static bool LessThan<T>(
            T leftNumerator, T leftDenominator, T rightNumerator, T rightDenominator)
            where T :
            IAdditionOperators<T, T, T>,
            IAdditiveIdentity<T, T>,
            IBinaryInteger<T>,
            IComparable<T>,
            IDecrementOperators<T>,
            IDivisionOperators<T, T, T>,
            IModulusOperators<T, T, T> =>
            RationalOperations.LessThan(
                leftNumerator, leftDenominator, rightNumerator, rightDenominator,
                T.AdditiveIdentity, UncheckedLessThanPolicy<T>.Instance);
    }
}
