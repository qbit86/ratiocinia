namespace Ratiocinia.Models
{
    using System.Numerics;

    public interface IUncheckedMultiplyFunctions<T> : IMultiplyFunctions<T>
        where T : IMultiplyOperators<T, T, T>
    {
        T IMultiplyFunctions<T>.Multiply(T left, T right) => left * right;
    }
}
