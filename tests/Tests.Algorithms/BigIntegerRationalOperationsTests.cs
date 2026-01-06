using System;
using System.Numerics;
using Ratiocinia.Algorithms.Specialized;

namespace Ratiocinia;

public sealed class BigIntegerRationalOperationsTests
{
    [Fact]
    public void Add_reduces_result()
    {
        var (n, d) = BigIntegerRationalOperations.Add(1, 2, 1, 2);
        Assert.Equal(new BigInteger(1), n);
        Assert.Equal(new BigInteger(1), d);
    }

    [Fact]
    public void Subtract_reduces_result()
    {
        var (n, d) = BigIntegerRationalOperations.Subtract(1, 2, 1, 6);
        Assert.Equal(new BigInteger(1), n);
        Assert.Equal(new BigInteger(3), d);
    }

    [Fact]
    public void Multiply_cancels_cross_factors()
    {
        var (n, d) = BigIntegerRationalOperations.Multiply(2, 3, 9, 4);
        Assert.Equal(new BigInteger(3), n);
        Assert.Equal(new BigInteger(2), d);
    }

    [Fact]
    public void Divide_normalizes_sign_to_keep_denominator_positive()
    {
        var (n, d) = BigIntegerRationalOperations.Divide(1, 2, -1, 3);
        Assert.Equal(new BigInteger(-3), n);
        Assert.Equal(new BigInteger(2), d);
    }

    [Fact]
    public void Divide_with_right_numerator_zero_throws()
    {
        var ex = Assert.Throws<ArgumentOutOfRangeException>(() => BigIntegerRationalOperations.Divide(1, 2, 0, 3));
        Assert.Equal("rightNumerator", ex.ParamName);
    }

    [Theory]
    [InlineData(0, 1, true)]
    [InlineData(0, 2, false)]
    [InlineData(1, 2, true)]
    [InlineData(2, 4, false)]
    [InlineData(-1, 2, true)]
    [InlineData(1, -2, false)]
    public void IsNormalized_matches_expected(BigInteger numerator, BigInteger denominator, bool expected)
        => Assert.Equal(expected, BigIntegerRationalOperations.IsNormalized(numerator, denominator));

    [Fact]
    public void Negate_flips_numerator_and_keeps_denominator()
    {
        var (n, d) = BigIntegerRationalOperations.Negate(new BigInteger(3), new BigInteger(7));
        Assert.Equal(new BigInteger(-3), n);
        Assert.Equal(new BigInteger(7), d);
    }
}
