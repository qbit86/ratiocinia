namespace Ratiocinia
{
    using System.Numerics;

    partial struct BigIntegerRational
    {
        public static BigIntegerRational MultiplicativeIdentity { get; } =
            UnsafeCreate(BigInteger.One, BigInteger.One);
    }
}
