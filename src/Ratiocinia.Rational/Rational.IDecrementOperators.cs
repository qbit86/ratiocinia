namespace Ratiocinia
{
    using System.Numerics;

    partial struct Rational<T> : IDecrementOperators<Rational<T>>
    {
        public static Rational<T> operator --(Rational<T> value) => Decrement(value);

        public static Rational<T> operator checked --(Rational<T> value) =>
            new(checked(value.Numerator - value.Denominator), value.Denominator);

        public static Rational<T> Decrement(Rational<T> value) =>
            new(value.Numerator - value.Denominator, value.Denominator);
    }
}
