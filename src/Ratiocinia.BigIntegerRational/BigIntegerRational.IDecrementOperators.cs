namespace Ratiocinia
{
    partial struct BigIntegerRational
    {
        public static BigIntegerRational operator --(BigIntegerRational value) => Decrement(value);

        public static BigIntegerRational operator checked --(BigIntegerRational value) => Decrement(value);

        public static BigIntegerRational Decrement(BigIntegerRational value) =>
            UnsafeCreate(value.Numerator - value.Denominator, value.Denominator);
    }
}
