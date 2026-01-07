namespace Ratiocinia
{
    using System.Numerics;

    partial struct Rational<T> : IAdditiveIdentity<Rational<T>, Rational<T>>
    {
        public static Rational<T> AdditiveIdentity { get; } = new(T.AdditiveIdentity, T.MultiplicativeIdentity);
    }
}
