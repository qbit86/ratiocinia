namespace Ratiocinia
{
    using System.Numerics;

    partial struct Rational<T> : IUnaryPlusOperators<Rational<T>, Rational<T>>
    {
        public static Rational<T> operator +(Rational<T> value) => value;

        public static Rational<T> Plus(Rational<T> value) => value;
    }
}
