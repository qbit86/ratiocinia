namespace Ratiocinia.Models
{
    using System.Numerics;

    public interface IPartialNumberCheckedPolicy<T> :
        IAdditionFunctions<T>,
        IDivisionFunctions<T>,
        IMultiplyFunctions<T>,
        ISubtractionFunctions<T>
        where T :
        IAdditionOperators<T, T, T>,
        IDivisionOperators<T, T, T>,
        IMultiplyOperators<T, T, T>,
        ISubtractionOperators<T, T, T>
    {
        T IAdditionFunctions<T>.Add(T left, T right) => checked(left + right);

        T IDivisionFunctions<T>.Divide(T left, T right) => checked(left / right);

        T IMultiplyFunctions<T>.Multiply(T left, T right) => checked(left * right);

        T ISubtractionFunctions<T>.Subtract(T left, T right) => checked(left - right);
    }
}
