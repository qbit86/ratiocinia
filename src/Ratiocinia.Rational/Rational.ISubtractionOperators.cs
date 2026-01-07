namespace Ratiocinia
{
    using Algorithms.Specialized;

    partial struct Rational<T>
    {
        public static Rational<T> operator -(Rational<T> left, Rational<T> right) =>
            Subtract(left, right);

        public static Rational<T> operator checked -(Rational<T> left, Rational<T> right)
        {
            var (numerator, denominator) = CheckedRationalOperations.Subtract(
                left.Numerator, left.Denominator, right.Numerator, right.Denominator);
            return UnsafeCreate(numerator, denominator);
        }

        public static Rational<T> Subtract(Rational<T> left, Rational<T> right)
        {
            var (numerator, denominator) = UncheckedRationalOperations.Subtract(
                left.Numerator, left.Denominator, right.Numerator, right.Denominator);
            return UnsafeCreate(numerator, denominator);
        }
    }
}
