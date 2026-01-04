namespace Ratiocinia.Models
{
    using System.Numerics;

    public interface INumberBaseGreatestCommonDivisorFunctions<T> : IGreatestCommonDivisorFunctions<T>
        where T : IModulusOperators<T, T, T>, INumberBase<T>
    {
        T IGreatestCommonDivisorFunctions<T>.Gcd(T left, T right) => IntegerOperations.GcdNumberBase(left, right);
    }
}
