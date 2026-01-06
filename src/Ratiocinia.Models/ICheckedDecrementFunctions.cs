namespace Ratiocinia.Models
{
    using System.Numerics;

    public interface ICheckedDecrementFunctions<T> : IDecrementFunctions<T>
        where T : IDecrementOperators<T>
    {
        T IDecrementFunctions<T>.Decrement(T value) => checked(--value);
    }
}
