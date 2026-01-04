namespace Ratiocinia.Models
{
    using System.Numerics;

    public interface IUncheckedUnaryNegationFunctions<T> : IUnaryNegationFunctions<T>
        where T : IUnaryNegationOperators<T, T>
    {
        T IUnaryNegationFunctions<T>.Negate(T value) => -value;
    }
}
