namespace Ratiocinia.Models
{
    using System;
    using System.Collections.Generic;
    using System.Numerics;

    public sealed class NumberUncheckedPolicy<T> :
        IPartialNumberUncheckedPolicy<T>,
        IGreatestCommonDivisorFunctionsImplementation<T>,
        IAdditiveIdentity<T>,
        IComparer<T>,
        IUnaryNegationFunctions<T>
        where T :
        IAdditionOperators<T, T, T>,
        IAdditiveIdentity<T, T>,
        IComparisonOperators<T, T, bool>,
        IDivisionOperators<T, T, T>,
        IEquatable<T>,
        IModulusOperators<T, T, T>,
        IMultiplyOperators<T, T, T>,
        ISubtractionOperators<T, T, T>,
        IUnaryNegationOperators<T, T>
    {
        public static NumberUncheckedPolicy<T> Instance { get; } = new();

        T IAdditiveIdentity<T>.AdditiveIdentity => T.AdditiveIdentity;

        int IComparer<T>.Compare(T? x, T? y) => Comparer<T>.Default.Compare(x, y);

        T IUnaryNegationFunctions<T>.Negate(T value) => -value;
    }
}
