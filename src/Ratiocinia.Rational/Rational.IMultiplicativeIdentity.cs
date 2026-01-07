namespace Ratiocinia
{
    partial struct Rational<T>
    {
        public static Rational<T> MultiplicativeIdentity { get; } =
            new(T.MultiplicativeIdentity, T.MultiplicativeIdentity);
    }
}
