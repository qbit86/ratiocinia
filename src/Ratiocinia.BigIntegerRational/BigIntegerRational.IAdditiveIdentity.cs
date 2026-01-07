namespace Ratiocinia
{
    using System.Numerics;

    partial struct BigIntegerRational
    {
        public static BigIntegerRational AdditiveIdentity { get; } =
            UnsafeCreate(BigInteger.Zero, BigInteger.One);
    }
}
