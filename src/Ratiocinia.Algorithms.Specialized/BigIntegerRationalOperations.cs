namespace Ratiocinia.Algorithms.Specialized
{
    using System.Numerics;
    using Generic;
    using Models;

    public static class BigIntegerRationalOperations
    {
        public static (BigInteger Numerator, BigInteger Denominator) Add(
            BigInteger leftNumerator, BigInteger leftDenominator, BigInteger rightNumerator,
            BigInteger rightDenominator) =>
            RationalOperations.Add(
                leftNumerator, leftDenominator, rightNumerator, rightDenominator, BigIntegerPolicy.Instance);

        public static (BigInteger Numerator, BigInteger Denominator) Divide(
            BigInteger leftNumerator, BigInteger leftDenominator, BigInteger rightNumerator,
            BigInteger rightDenominator) =>
            RationalOperations.Divide(
                leftNumerator, leftDenominator, rightNumerator, rightDenominator,
                BigInteger.Zero, BigIntegerPolicy.Instance);

        public static (BigInteger Numerator, BigInteger Denominator) Multiply(
            BigInteger leftNumerator, BigInteger leftDenominator, BigInteger rightNumerator,
            BigInteger rightDenominator) =>
            RationalOperations.Multiply(
                leftNumerator, leftDenominator, rightNumerator, rightDenominator, BigIntegerPolicy.Instance);

        public static (BigInteger Numerator, BigInteger Denominator) Subtract(
            BigInteger leftNumerator, BigInteger leftDenominator, BigInteger rightNumerator,
            BigInteger rightDenominator) =>
            RationalOperations.Subtract(
                leftNumerator, leftDenominator, rightNumerator, rightDenominator, BigIntegerPolicy.Instance);

        public static (BigInteger Numerator, BigInteger Denominator) Negate(
            BigInteger numerator, BigInteger denominator) =>
            RationalOperations.Negate(numerator, denominator, BigIntegerPolicy.Instance);

        public static (BigInteger Numerator, BigInteger Denominator) Normalize(
            BigInteger numerator, BigInteger denominator) =>
            RationalOperations.Normalize(
                numerator,
                denominator,
                BigInteger.Zero,
                BigInteger.One,
                BigInteger.Zero,
                BigIntegerPolicy.Instance);

        public static bool IsNormalized(BigInteger numerator, BigInteger denominator) =>
            RationalOperations.IsNormalized(
                numerator, denominator, BigInteger.Zero, BigInteger.One, BigIntegerPolicy.Instance);

        public static bool LessThan(
            BigInteger leftNumerator, BigInteger leftDenominator, BigInteger rightNumerator,
            BigInteger rightDenominator) =>
            RationalOperations.LessThan(
                leftNumerator, leftDenominator, rightNumerator, rightDenominator,
                BigInteger.Zero, BigIntegerPolicy.Instance);
    }
}
