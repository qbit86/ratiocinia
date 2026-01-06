using Ratiocinia.Algorithms.Generic;
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
    public void LessThan_int32_matches_expected(
        int leftNumerator, int leftDenominator, int rightNumerator, int rightDenominator, bool expected)
    {
        bool actual = RationalOperations.LessThan(
            leftNumerator, leftDenominator, rightNumerator, rightDenominator, 0, CheckedLessThanPolicy<int>.Instance);

        Assert.Equal(expected, actual);
    }
}
