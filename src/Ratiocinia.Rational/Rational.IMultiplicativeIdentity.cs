namespace Ratiocinia
{
    partial struct Rational<T>
    {
        public static Rational<T> MultiplicativeIdentity { get; } =
            UnsafeCreate(T.MultiplicativeIdentity, T.MultiplicativeIdentity);
    }
}
