namespace Ratiocinia.Models
{
    using System.Numerics;

    public interface IBinaryDivRemFunctions<T> : IDivRemFunctions<T>
        where T : IBinaryInteger<T>
    {
        (T Quotient, T Remainder) IDivRemFunctions<T>.DivRem(T left, T right) => T.DivRem(left, right);
    }
}
