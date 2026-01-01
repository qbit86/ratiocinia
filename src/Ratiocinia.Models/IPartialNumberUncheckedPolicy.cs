namespace Ratiocinia.Models
{
    using System.Numerics;

    public interface IPartialNumberUncheckedPolicy<T> :
        IAdditionFunctions<T>,
        IDivisionFunctions<T>,
        IMultiplyFunctions<T>
        where T :
        IAdditionOperators<T, T, T>,
        IDivisionOperators<T, T, T>,
        IMultiplyOperators<T, T, T>
    {
        T IAdditionFunctions<T>.Add(T left, T right) => left + right;

        T IDivisionFunctions<T>.Divide(T left, T right) => left / right;

        T IMultiplyFunctions<T>.Multiply(T left, T right) => left * right;
    }
}
