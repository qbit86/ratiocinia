using Ratiocinia.Algorithms.Generic.Internal;
using Ratiocinia.Models;

namespace Ratiocinia;

public sealed class RationalOperationsLessThanTests
{
    [Theory]
    // Both continued-fraction expansions end together => equal => false.
    // This specifically guards against the bug where 1/2 < 2/4 would incorrectly return true.
    [InlineData(1, 2, 2, 4, false)]
    // One expansion ends earlier; parity must match Boost's "(leftRemainder != 0) != reverse" logic.
    [InlineData(1, 2, 2, 5, false)]
    [InlineData(2, 5, 1, 2, true)]
    // Edge cases: zero comparisons
    [InlineData(0, 1, 1, 1, true)] // 0 < 1
    [InlineData(1, 1, 0, 1, false)] // 1 < 0 is false
    [InlineData(0, 1, 0, 1, false)] // 0 < 0 is false (equal)
    // Edge cases: negative vs positive
    [InlineData(-1, 2, 1, 2, true)] // -1/2 < 1/2
    [InlineData(1, 2, -1, 2, false)] // 1/2 < -1/2 is false
    // Negative values comparison
    [InlineData(-1, 2, -1, 3, true)] // -1/2 < -1/3 (more negative)
    [InlineData(-1, 3, -1, 2, false)] // -1/3 < -1/2 is false
    [InlineData(-2, 3, -1, 2, true)] // -2/3 < -1/2 (more negative)
    [InlineData(-1, 2, -2, 3, false)] // -1/2 < -2/3 is false
    [InlineData(-3, 4, -3, 4, false)] // equal negatives
    // Same sign, different magnitudes (positive)
    [InlineData(1, 3, 1, 2, true)] // 1/3 < 1/2
    [InlineData(1, 2, 1, 3, false)] // 1/2 < 1/3 is false
    [InlineData(2, 3, 3, 4, true)] // 2/3 < 3/4
    [InlineData(3, 4, 2, 3, false)] // 3/4 < 2/3 is false
    [InlineData(1, 4, 3, 4, true)] // 1/4 < 3/4
    // Same sign, different magnitudes (negative)
    [InlineData(-3, 4, -1, 4, true)] // -3/4 < -1/4
    [InlineData(-1, 4, -3, 4, false)] // -1/4 < -3/4 is false
    // Large values near overflow boundaries
    [InlineData(int.MaxValue, 1, int.MaxValue - 1, 1, false)] // MaxValue > MaxValue-1
    [InlineData(int.MaxValue - 1, 1, int.MaxValue, 1, true)] // MaxValue-1 < MaxValue
    [InlineData(int.MaxValue, 2, int.MaxValue, 3, false)] // MaxValue/2 > MaxValue/3
    [InlineData(int.MaxValue, 3, int.MaxValue, 2, true)] // MaxValue/3 < MaxValue/2
    [InlineData(1, int.MaxValue, 1, int.MaxValue - 1, true)] // 1/MaxValue < 1/(MaxValue-1)
    [InlineData(1, int.MaxValue - 1, 1, int.MaxValue, false)] // 1/(MaxValue-1) > 1/MaxValue
    // Integer comparisons (denominator = 1)
    [InlineData(1, 1, 2, 1, true)] // 1 < 2
    [InlineData(2, 1, 1, 1, false)] // 2 < 1 is false
    [InlineData(5, 1, 5, 1, false)] // 5 < 5 is false (equal)
    [InlineData(-2, 1, -1, 1, true)] // -2 < -1
    [InlineData(-1, 1, -2, 1, false)] // -1 < -2 is false
    public void LessThan_int32_matches_expected(
        int leftNumerator, int leftDenominator, int rightNumerator, int rightDenominator, bool expected)
    {
        bool actual = RationalOperations.LessThan(
            leftNumerator, leftDenominator, rightNumerator, rightDenominator, 0, CheckedLessThanPolicy<int>.Instance);

        Assert.Equal(expected, actual);
    }
}
