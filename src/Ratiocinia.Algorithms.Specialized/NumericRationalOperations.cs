namespace Ratiocinia.Algorithms.Specialized
{
    using System;
    using System.Numerics;
    using Generic;
    using Models;

    public static class NumericRationalOperations
    {
        public static bool IsNormalized<T>(T numerator, T denominator)
            where T : IAdditiveIdentity<T, T>, IComparable<T>, IEquatable<T>,
            IModulusOperators<T, T, T>, IMultiplicativeIdentity<T, T>, INumberBase<T>
        {
            var policy = Policy<T>.Instance;
            return RationalOperations.IsNormalized(
                numerator, denominator, T.AdditiveIdentity, T.MultiplicativeIdentity, policy);
        }
    }

    file sealed class Policy<T> : INumberBaseGreatestCommonDivisorFunctions<T>, INumberBaseAbsoluteFunctions<T>
        where T : IModulusOperators<T, T, T>, INumberBase<T>
    {
        internal static Policy<T> Instance { get; } = new();
    }
}
