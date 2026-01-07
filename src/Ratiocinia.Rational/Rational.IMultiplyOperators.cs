namespace Ratiocinia
{
    using Algorithms.Specialized;

    partial struct Rational<T>
    {
        public static Rational<T> operator *(Rational<T> left, Rational<T> right) =>
            Multiply(left, right);

        public static Rational<T> operator checked *(Rational<T> left, Rational<T> right)
        {
            var (numerator, denominator) = CheckedRationalOperations.Multiply(
                left.Numerator, left.Denominator, right.Numerator, right.Denominator);
            return new(numerator, denominator);
        }

        public static Rational<T> Multiply(Rational<T> left, Rational<T> right)
        {
            var (numerator, denominator) = UncheckedRationalOperations.Multiply(
                left.Numerator, left.Denominator, right.Numerator, right.Denominator);
            return new(numerator, denominator);
        }
    }
}
