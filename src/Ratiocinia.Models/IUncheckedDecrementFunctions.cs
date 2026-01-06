namespace Ratiocinia.Models
{
    using System.Numerics;

    public interface IUncheckedDecrementFunctions<T> : IDecrementFunctions<T>
        where T : IDecrementOperators<T>
    {
        T IDecrementFunctions<T>.Decrement(T value) => --value;
    }
}
