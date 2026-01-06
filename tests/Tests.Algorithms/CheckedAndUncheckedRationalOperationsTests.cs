using System;
using Ratiocinia.Algorithms.Specialized;

namespace Ratiocinia;

public sealed class CheckedAndUncheckedRationalOperationsTests
{
    [Fact]
    public void Checked_Add_reduces_result()
    {
        (int n, int d) = CheckedRationalOperations.Add(1, 2, 1, 2);
        Assert.Equal(1, n);
        Assert.Equal(1, d);
    }

    [Fact]
    public void Unchecked_Add_reduces_result()
    {
        (int n, int d) = UncheckedRationalOperations.Add(1, 2, 1, 2);
        Assert.Equal(1, n);
        Assert.Equal(1, d);
    }

    [Fact]
    public void Checked_Divide_with_right_numerator_zero_throws()
    {
        var ex = Assert.Throws<ArgumentOutOfRangeException>(() => CheckedRationalOperations.Divide(1, 2, 0, 3));
        Assert.Equal("rightNumerator", ex.ParamName);
    }

    [Fact]
    public void Unchecked_Divide_with_right_numerator_zero_throws()
    {
        var ex = Assert.Throws<ArgumentOutOfRangeException>(() => UncheckedRationalOperations.Divide(1, 2, 0, 3));
        Assert.Equal("rightNumerator", ex.ParamName);
    }

    [Fact]
    public void Checked_Add_overflow_throws() =>
        Assert.Throws<OverflowException>(() => CheckedRationalOperations.Add(int.MaxValue, 1, 1, 1));

    [Fact]
    public void Unchecked_Add_overflow_wraps()
    {
        (int n, int d) = UncheckedRationalOperations.Add(int.MaxValue, 1, 1, 1);
        Assert.Equal(int.MinValue, n);
        Assert.Equal(1, d);
    }

    [Fact]
    public void Checked_Negate_overflow_throws() =>
        Assert.Throws<OverflowException>(() => CheckedRationalOperations.Negate(int.MinValue, 1));

    [Fact]
    public void Unchecked_Negate_overflow_wraps()
    {
        (int n, int d) = UncheckedRationalOperations.Negate(int.MinValue, 1);
        Assert.Equal(int.MinValue, n);
        Assert.Equal(1, d);
    }
}
