using Ratiocinia.Algorithms.Specialized;

namespace Ratiocinia;

public sealed class NumericRationalOperationsTests
{
    [Theory]
    [InlineData(0, 1, true)]
    [InlineData(0, 2, false)]
    [InlineData(1, 2, true)]
    [InlineData(2, 4, false)]
    [InlineData(-1, 2, true)]
    [InlineData(1, 0, false)]
    [InlineData(1, -2, false)]
    public void IsNormalized_int32_matches_expected(int numerator, int denominator, bool expected)
        => Assert.Equal(expected, NumericRationalOperations.IsNormalized(numerator, denominator));
}
