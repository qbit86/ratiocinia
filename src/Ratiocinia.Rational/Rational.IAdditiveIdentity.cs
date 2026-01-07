namespace Ratiocinia
{
    partial struct Rational<T>
    {
        public static Rational<T> AdditiveIdentity { get; } = new(T.AdditiveIdentity, T.MultiplicativeIdentity);
    }
}
