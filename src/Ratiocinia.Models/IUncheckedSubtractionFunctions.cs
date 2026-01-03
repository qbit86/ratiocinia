namespace Ratiocinia.Models
{
    using System.Numerics;

    public interface IUncheckedSubtractionFunctions<T> : ISubtractionFunctions<T>
        where T : ISubtractionOperators<T, T, T>
    {
        T ISubtractionFunctions<T>.Subtract(T left, T right) => left - right;
    }
}
