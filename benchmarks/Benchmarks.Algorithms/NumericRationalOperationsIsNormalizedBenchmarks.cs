using BenchmarkDotNet.Attributes;
using Ratiocinia.Algorithms.Specialized;

namespace Ratiocinia;

[MemoryDiagnoser]
public class NumericRationalOperationsIsNormalizedBenchmarks
{
    // Normalization rules (from Generic.RationalOperations.IsNormalized):
    // - denominator must be > 0
    // - if numerator == 0, denominator must be 1
    // - gcd(numerator, denominator) must have abs == 1

    [Benchmark(Description = "IsNormalized<long>(1, 2) => true")]
    public bool Normalized1Over2() => NumericRationalOperations.IsNormalized<long>(1, 2);

    [Benchmark(Description = "IsNormalized<long>(2, 4) => false")]
    public bool NotNormalized2Over4() => NumericRationalOperations.IsNormalized<long>(2, 4);

    [Benchmark(Description = "IsNormalized<long>(0, 1) => true")]
    public bool Normalized0Over1() => NumericRationalOperations.IsNormalized<long>(0, 1);

    [Benchmark(Description = "IsNormalized<long>(0, 2) => false")]
    public bool NotNormalized0Over2() => NumericRationalOperations.IsNormalized<long>(0, 2);

    [Benchmark(Description = "IsNormalized<long>(1, -2) => false")]
    public bool NotNormalizedDenominatorNegative1OverMinus2() => NumericRationalOperations.IsNormalized<long>(1, -2);

    [Benchmark(Description = "IsNormalized<long>(-1, 2) => true")]
    public bool NormalizedNegativeNumeratorMinus1Over2() => NumericRationalOperations.IsNormalized<long>(-1, 2);
}
