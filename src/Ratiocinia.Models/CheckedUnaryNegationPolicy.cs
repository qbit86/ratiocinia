namespace Ratiocinia.Models
{
    using System.Numerics;

    public sealed class CheckedUnaryNegationPolicy<T> : ICheckedUnaryNegationFunctions<T>
        where T : IUnaryNegationOperators<T, T>
    {
        public static CheckedUnaryNegationPolicy<T> Instance { get; } = new();
    }
}
