namespace Ratiocinia.Models
{
    using System.Numerics;

    public interface ICheckedUnaryNegationFunctions<T> : IUnaryNegationFunctions<T>
        where T : IUnaryNegationOperators<T, T>
    {
        T IUnaryNegationFunctions<T>.Negate(T value) => checked(-value);
    }
}
