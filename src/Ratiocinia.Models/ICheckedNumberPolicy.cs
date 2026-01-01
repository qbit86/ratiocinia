namespace Ratiocinia.Models
{
    using System.Numerics;

    public interface ICheckedNumberPolicy<T> : IAdditionFunctions<T>, IMultiplyFunctions<T>
        where T : IAdditionOperators<T, T, T>, IMultiplyOperators<T, T, T>
    {
        T IAdditionFunctions<T>.Add(T left, T right) => checked(left + right);

        T IMultiplyFunctions<T>.Multiply(T left, T right) => checked(left * right);
    }

    public sealed class CheckedNumberPolicy<T> : ICheckedNumberPolicy<T>
        where T : IAdditionOperators<T, T, T>, IMultiplyOperators<T, T, T>
    {
        public static CheckedNumberPolicy<T> Instance { get; } = new();
    }
}
