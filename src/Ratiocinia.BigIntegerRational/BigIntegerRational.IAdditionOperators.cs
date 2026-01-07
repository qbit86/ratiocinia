namespace Ratiocinia
{
    using Algorithms.Specialized;

    partial struct BigIntegerRational
    {
        public static BigIntegerRational operator +(BigIntegerRational left, BigIntegerRational right) =>
            Add(left, right);

        public static BigIntegerRational operator checked +(BigIntegerRational left, BigIntegerRational right) =>
            Add(left, right);

        public static BigIntegerRational Add(BigIntegerRational left, BigIntegerRational right)
        {
            var (numerator, denominator) = BigIntegerRationalOperations.Add(
                left.Numerator, left.Denominator, right.Numerator, right.Denominator);
            return UnsafeCreate(numerator, denominator);
        }
    }
}
