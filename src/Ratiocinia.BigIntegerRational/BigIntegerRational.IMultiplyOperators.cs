namespace Ratiocinia
{
    using Algorithms.Specialized;

    partial struct BigIntegerRational
    {
        public static BigIntegerRational operator *(BigIntegerRational left, BigIntegerRational right) =>
            Multiply(left, right);

        public static BigIntegerRational operator checked *(BigIntegerRational left, BigIntegerRational right) =>
            Multiply(left, right);

        public static BigIntegerRational Multiply(BigIntegerRational left, BigIntegerRational right)
        {
            var (numerator, denominator) = BigIntegerRationalOperations.Multiply(
                left.Numerator, left.Denominator, right.Numerator, right.Denominator);
            return UnsafeCreate(numerator, denominator);
        }
    }
}
