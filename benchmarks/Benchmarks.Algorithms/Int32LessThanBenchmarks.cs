using System;
using BenchmarkDotNet.Attributes;
using Ratiocinia.Algorithms.Generic;
using Ratiocinia.Models;

namespace Ratiocinia;

[MemoryDiagnoser]
public class Int32LessThanBenchmarks
{
    private (int Ln, int Ld, int Rn, int Rd)[] _cases = null!;

    [Params(0, 1, 2, 3)] public int CaseIndex { get; set; }

    [GlobalSetup]
    public void Setup()
    {
        // Intentionally seeded from large-magnitude Int32 values.
        // Denominators must be > 0 to satisfy RationalOperations.LessThan() debug assertions.
        _cases =
        [
            // Mixed signs, huge denominators
            (int.MinValue, int.MaxValue, int.MaxValue, int.MaxValue - 1),

            // Close values to stress continued-fraction iterations
            (int.MaxValue - 123, int.MaxValue - 7, int.MaxValue - 124, int.MaxValue - 6),

            // Negative vs. positive numerator with large denominators
            (-2_000_000_000, int.MaxValue, 2_000_000_000, int.MaxValue - 3),

            // Large but different scale between numerator/denominator
            (int.MaxValue - 10_000, int.MaxValue - 123, -(int.MaxValue - 20_000), int.MaxValue)
        ];
    }

    [Benchmark(Description = "Int32 LessThan via continued fraction (RationalOperations.LessThan)")]
    public bool ContinuedFraction()
    {
        (int ln, int ld, int rn, int rd) = _cases[CaseIndex];
        return RationalOperations.LessThan(ln, ld, rn, rd, 0, UncheckedLessThanPolicy<int>.Instance);
    }

    [Benchmark(Description = "Int32 LessThan via cross-multiplication (Math.BigMul)")]
    public bool CrossMultiplyBigMul()
    {
        (int ln, int ld, int rn, int rd) = _cases[CaseIndex];
        return Math.BigMul(ln, rd) < Math.BigMul(rn, ld);
    }
}
