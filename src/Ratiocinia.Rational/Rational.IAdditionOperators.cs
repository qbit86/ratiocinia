namespace Ratiocinia
{
    using System.Numerics;
    using Algorithms.Specialized;

    partial struct Rational<T> : IAdditionOperators<Rational<T>, Rational<T>, Rational<T>>
    {
        public static Rational<T> operator +(Rational<T> left, Rational<T> right) =>
            Add(left, right);

        public static Rational<T> operator checked +(Rational<T> left, Rational<T> right)
        {
            var (numerator, denominator) = CheckedRationalOperations.Add(
                left.Numerator, left.Denominator, right.Numerator, right.Denominator);
            return new(numerator, denominator);
        }

        public static Rational<T> Add(Rational<T> left, Rational<T> right)
        {
            var (numerator, denominator) = UncheckedRationalOperations.Add(
                left.Numerator, left.Denominator, right.Numerator, right.Denominator);
            return new(numerator, denominator);
        }
    }
}
