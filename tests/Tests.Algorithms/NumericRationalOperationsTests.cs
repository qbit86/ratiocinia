using System.Globalization;
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

    [Fact]
    public void TryParse_honors_NumberStyles_whitespace()
    {
        const string input = " 1/2 ";

        bool parsedNone = NumericRationalOperations.TryParse<int>(
            input, NumberStyles.None, CultureInfo.InvariantCulture, out _, out _);

        bool parsedInteger = NumericRationalOperations.TryParse(
            input, NumberStyles.Integer, CultureInfo.InvariantCulture, out int numerator, out int denominator);

        Assert.False(parsedNone);
        Assert.True(parsedInteger);
        Assert.Equal(1, numerator);
        Assert.Equal(2, denominator);
    }
}
