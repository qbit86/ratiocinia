namespace Ratiocinia
{
    partial struct Rational<T>
    {
        public static Rational<T> AdditiveIdentity { get; } =
            UnsafeCreate(T.AdditiveIdentity, T.MultiplicativeIdentity);
    }
}
