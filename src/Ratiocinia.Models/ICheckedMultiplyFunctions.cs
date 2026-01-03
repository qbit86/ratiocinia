namespace Ratiocinia.Models
{
    using System.Numerics;

    public interface ICheckedMultiplyFunctions<T> : IMultiplyFunctions<T>
        where T : IMultiplyOperators<T, T, T>
    {
        T IMultiplyFunctions<T>.Multiply(T left, T right) => checked(left * right);
    }
}
