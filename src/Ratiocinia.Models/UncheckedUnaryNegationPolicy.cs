namespace Ratiocinia.Models
{
    using System.Numerics;

    public sealed class UncheckedUnaryNegationPolicy<T> : IUncheckedUnaryNegationFunctions<T>
        where T : IUnaryNegationOperators<T, T>
    {
        public static UncheckedUnaryNegationPolicy<T> Instance { get; } = new();
    }
}
