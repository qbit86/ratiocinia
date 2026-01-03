namespace Ratiocinia.Models
{
    using System.Numerics;

    public interface IUncheckedAdditionFunctions<T> : IAdditionFunctions<T>
        where T : IAdditionOperators<T, T, T>
    {
        T IAdditionFunctions<T>.Add(T left, T right) => left + right;
    }
}
