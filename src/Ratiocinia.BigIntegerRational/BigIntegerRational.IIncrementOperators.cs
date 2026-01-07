namespace Ratiocinia
{
    partial struct BigIntegerRational
    {
        public static BigIntegerRational operator ++(BigIntegerRational value) => Increment(value);

        public static BigIntegerRational operator checked ++(BigIntegerRational value) => Increment(value);

        public static BigIntegerRational Increment(BigIntegerRational value) =>
            UnsafeCreate(value.Numerator + value.Denominator, value.Denominator);
    }
}
