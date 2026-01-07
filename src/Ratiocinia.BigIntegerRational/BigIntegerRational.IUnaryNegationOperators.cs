namespace Ratiocinia
{
    using Algorithms.Specialized;

    partial struct BigIntegerRational
    {
        public static BigIntegerRational operator -(BigIntegerRational value) => Negate(value);

        public static BigIntegerRational operator checked -(BigIntegerRational value) => Negate(value);

        public static BigIntegerRational Negate(BigIntegerRational value)
        {
            var (numerator, denominator) = BigIntegerRationalOperations.Negate(value.Numerator, value.Denominator);
            return UnsafeCreate(numerator, denominator);
        }
    }
}
