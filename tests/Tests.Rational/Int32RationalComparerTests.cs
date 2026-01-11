using System;

namespace Ratiocinia;

public sealed class Int32RationalComparerTests
{
    public static TheoryData<int, int, int, int, int> CompareCases { get; } = new()
    {
        // Basic cases - returns negative, zero, or positive
        { 1, 2, 3, 4, -1 }, // 1/2 < 3/4
        { 3, 4, 1, 2, 1 }, // 3/4 > 1/2
        { 1, 2, 1, 2, 0 }, // 1/2 == 1/2
        { 1, 3, 1, 2, -1 }, // 1/3 < 1/2
        { 2, 3, 1, 2, 1 }, // 2/3 > 1/2

        // Negative numerators
        { -1, 2, 1, 2, -1 }, // -1/2 < 1/2
        { -1, 2, -1, 4, -1 }, // -1/2 < -1/4
        { -1, 4, -1, 2, 1 }, // -1/4 > -1/2

        // Zero numerator
        { 0, 1, 1, 2, -1 }, // 0 < 1/2
        { 0, 1, -1, 2, 1 }, // 0 > -1/2
        { 0, 1, 0, 1, 0 }, // 0 == 0

        // Large values that would overflow with simple multiplication
        { int.MaxValue, int.MaxValue, int.MaxValue - 1, int.MaxValue, 1 }, // ~1 > ~0.9999...
        { int.MaxValue - 1, int.MaxValue, int.MaxValue, int.MaxValue, -1 }, // ~0.9999... < 1
        { int.MinValue + 1, int.MaxValue, int.MaxValue, int.MaxValue - 1, -1 }, // negative < positive
        { int.MinValue + 1, 1, int.MaxValue, 1, -1 } // min < max
    };

    [Theory]
    [MemberData(nameof(CompareCases))]
    public void Compare_returns_expected_sign(int ln, int ld, int rn, int rd, int expectedSign)
    {
        var comparer = Int32RationalComparer.Instance;
        var left = Rational.Create(ln, ld);
        var right = Rational.Create(rn, rd);

        int result = comparer.Compare(left, right);

        // Compare signs rather than exact values
        Assert.Equal(expectedSign, Math.Sign(result));
    }

    [Fact]
    public void Instance_returns_singleton()
    {
        var instance1 = Int32RationalComparer.Instance;
        var instance2 = Int32RationalComparer.Instance;

        Assert.Same(instance1, instance2);
    }

    [Fact]
    public void Compare_handles_extreme_values_without_overflow()
    {
        var comparer = Int32RationalComparer.Instance;

        // Equal extreme values
        var left = Rational.Create(int.MaxValue, int.MaxValue);
        var right = Rational.Create(int.MaxValue, int.MaxValue);
        int result = comparer.Compare(left, right);
        Assert.Equal(0, result);

        // Large negative vs large positive
        left = Rational.Create(int.MinValue + 1, 1);
        right = Rational.Create(int.MaxValue, 1);
        result = comparer.Compare(left, right);
        Assert.True(result < 0);
    }

    [Fact]
    public void Comparer_implements_IComparer_interface()
    {
        var comparer = Int32RationalComparer.Instance;

        var left = Rational.Create(1, 2);
        var right = Rational.Create(3, 4);

        Assert.True(comparer.Compare(left, right) < 0);
        Assert.True(comparer.Compare(right, left) > 0);
        Assert.Equal(0, comparer.Compare(left, left));
    }

    [Fact]
    public void Compare_with_equivalent_fractions_returns_zero()
    {
        var comparer = Int32RationalComparer.Instance;

        // Note: Rational.Create normalizes fractions, so 2/4 becomes 1/2
        var left = Rational.Create(1, 2);
        var right = Rational.Create(2, 4);

        Assert.Equal(0, comparer.Compare(left, right));
    }
}
