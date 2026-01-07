namespace Ratiocinia
{
    using Algorithms.Specialized;

    partial struct Rational<T>
    {
        public static Rational<T> operator -(Rational<T> value) => Negate(value);

        public static Rational<T> operator checked -(Rational<T> value)
        {
            var (numerator, denominator) = CheckedRationalOperations.Negate(value.Numerator, value.Denominator);
            return new(numerator, denominator);
        }

        public static Rational<T> Negate(Rational<T> value)
        {
            var (numerator, denominator) = UncheckedRationalOperations.Negate(value.Numerator, value.Denominator);
            return new(numerator, denominator);
        }
    }
}
