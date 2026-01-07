namespace Ratiocinia
{
    using System.Numerics;

    partial struct Rational<T> : IMultiplicativeIdentity<Rational<T>, Rational<T>>
    {
        public static Rational<T> MultiplicativeIdentity { get; } =
            new(T.MultiplicativeIdentity, T.MultiplicativeIdentity);
    }
}
