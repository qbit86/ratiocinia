namespace Ratiocinia
{
    using Algorithms.Specialized;

    partial struct Rational<T>
    {
        public static Rational<T> operator /(Rational<T> left, Rational<T> right) =>
            Divide(left, right);

        public static Rational<T> operator checked /(Rational<T> left, Rational<T> right)
        {
            var (numerator, denominator) = CheckedRationalOperations.Divide(
                left.Numerator, left.Denominator, right.Numerator, right.Denominator);
            return new(numerator, denominator);
        }

        public static Rational<T> Divide(Rational<T> left, Rational<T> right)
        {
            var (numerator, denominator) = UncheckedRationalOperations.Divide(
                left.Numerator, left.Denominator, right.Numerator, right.Denominator);
            return new(numerator, denominator);
        }
    }
}
