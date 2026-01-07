namespace Ratiocinia
{
    partial struct Rational<T>
    {
        public static Rational<T> operator +(Rational<T> value) => value;

        public static Rational<T> Plus(Rational<T> value) => value;
    }
}
