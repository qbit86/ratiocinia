using System.Numerics;
using BenchmarkDotNet.Attributes;
using Ratiocinia.Algorithms.Generic.Internal;
using Ratiocinia.Models;

namespace Ratiocinia;

[MemoryDiagnoser]
public class BigIntegerLessThanBenchmarks
{
    private (BigInteger Ln, BigInteger Ld, BigInteger Rn, BigInteger Rd)[] _cases = null!;

    [Params(0, 1, 2, 3)] public int CaseIndex { get; set; }

    [GlobalSetup]
    public void Setup()
    {
        // Intentionally seeded from large-magnitude Int64 values (then converted to BigInteger).
        // Denominators must be > 0 to satisfy RationalOperations.LessThan() debug assertions.
        _cases =
        [
            // Mixed signs, huge denominators
            (new BigInteger(long.MinValue), new BigInteger(long.MaxValue), new BigInteger(long.MaxValue),
                new BigInteger(long.MaxValue - 1)),

            // Close values to stress continued-fraction iterations
            (new BigInteger(long.MaxValue - 123), new BigInteger(long.MaxValue - 7),
                new BigInteger(long.MaxValue - 124), new BigInteger(long.MaxValue - 6)),

            // Negative vs. positive numerator with large denominators
            (new BigInteger(-9_000_000_000_000_000_000L), new BigInteger(9_223_372_036_854_775_807L),
                new BigInteger(9_000_000_000_000_000_000L), new BigInteger(9_223_372_036_854_775_001L)),

            // Large but different scale between numerator/denominator
            (new BigInteger(9_223_372_036_854_775_000L), new BigInteger(9_223_372_036_854_000_123L),
                new BigInteger(-9_223_372_036_854_000_120L), new BigInteger(9_223_372_036_854_775_807L))
        ];
    }

    [Benchmark(Description = "BigInteger LessThan via continued fraction (RationalOperations.LessThan)")]
    public bool ContinuedFraction()
    {
        var (ln, ld, rn, rd) = _cases[CaseIndex];
        return RationalOperations.LessThan(
            ln, ld, rn, rd,
            BigInteger.Zero, BigIntegerPolicy.Instance);
    }

    [Benchmark(Description = "BigInteger LessThan via cross-multiplication (ln*rd < rn*ld)")]
    public bool CrossMultiply()
    {
        var (ln, ld, rn, rd) = _cases[CaseIndex];
        return ln * rd < rn * ld;
    }
}
