namespace Ratiocinia
{
    partial struct Rational<T>
    {
        public static Rational<T> operator --(Rational<T> value) => Decrement(value);

        public static Rational<T> operator checked --(Rational<T> value) =>
            UnsafeCreate(checked(value.Numerator - value.Denominator), value.Denominator);

        public static Rational<T> Decrement(Rational<T> value) =>
            UnsafeCreate(value.Numerator - value.Denominator, value.Denominator);
    }
}
