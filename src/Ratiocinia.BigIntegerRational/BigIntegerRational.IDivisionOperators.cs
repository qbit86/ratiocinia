namespace Ratiocinia
{
    using Algorithms.Specialized;

    partial struct BigIntegerRational
    {
        public static BigIntegerRational operator /(BigIntegerRational left, BigIntegerRational right) =>
            Divide(left, right);

        public static BigIntegerRational operator checked /(BigIntegerRational left, BigIntegerRational right) =>
            Divide(left, right);

        public static BigIntegerRational Divide(BigIntegerRational left, BigIntegerRational right)
        {
            var (numerator, denominator) = BigIntegerRationalOperations.Divide(
                left.Numerator, left.Denominator, right.Numerator, right.Denominator);
            return UnsafeCreate(numerator, denominator);
        }
    }
}
