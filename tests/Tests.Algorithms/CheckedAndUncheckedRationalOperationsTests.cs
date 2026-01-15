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

    [Fact]
    public void Checked_Normalize_with_denominator_zero_throws()
    {
        var ex = Assert.Throws<ArgumentOutOfRangeException>(() => CheckedRationalOperations.Normalize(1, 0));
        Assert.Equal("denominator", ex.ParamName);
    }

    [Fact]
    public void Unchecked_Normalize_with_denominator_zero_throws()
    {
        var ex = Assert.Throws<ArgumentOutOfRangeException>(() => UncheckedRationalOperations.Normalize(1, 0));
        Assert.Equal("denominator", ex.ParamName);
    }

    [Fact]
    public void Checked_Normalize_reduces_by_gcd()
    {
        (int n, int d) = CheckedRationalOperations.Normalize(2, 4);
        Assert.Equal(1, n);
        Assert.Equal(2, d);
    }

    [Fact]
    public void Unchecked_Normalize_reduces_by_gcd()
    {
        (int n, int d) = UncheckedRationalOperations.Normalize(2, 4);
        Assert.Equal(1, n);
        Assert.Equal(2, d);
    }

    [Fact]
    public void Checked_Normalize_with_numerator_zero_returns_zero_over_one()
    {
        (int n, int d) = CheckedRationalOperations.Normalize(0, 7);
        Assert.Equal(0, n);
        Assert.Equal(1, d);
    }

    [Fact]
    public void Unchecked_Normalize_with_numerator_zero_returns_zero_over_one()
    {
        (int n, int d) = UncheckedRationalOperations.Normalize(0, 7);
        Assert.Equal(0, n);
        Assert.Equal(1, d);
    }

    [Fact]
    public void Checked_Normalize_normalizes_sign_to_keep_denominator_positive()
    {
        (int n, int d) = CheckedRationalOperations.Normalize(1, -2);
        Assert.Equal(-1, n);
        Assert.Equal(2, d);
    }

    [Fact]
    public void Unchecked_Normalize_normalizes_sign_to_keep_denominator_positive()
    {
        (int n, int d) = UncheckedRationalOperations.Normalize(1, -2);
        Assert.Equal(-1, n);
        Assert.Equal(2, d);
    }

    [Fact]
    public void Checked_Normalize_overflow_throws()
        => Assert.Throws<OverflowException>(() => CheckedRationalOperations.Normalize(1, int.MinValue));

    [Fact]
    public void Checked_Divide_one_by_negative_one_returns_negative_one()
    {
        (int n, int d) = CheckedRationalOperations.Divide(1, 1, -1, 1);
        Assert.Equal(-1, n);
        Assert.Equal(1, d);
    }

    [Fact]
    public void Unchecked_Divide_one_by_negative_one_returns_negative_one()
    {
        (int n, int d) = UncheckedRationalOperations.Divide(1, 1, -1, 1);
        Assert.Equal(-1, n);
        Assert.Equal(1, d);
    }

    [Fact]
    public void Checked_Multiply_one_by_negative_one_returns_negative_one()
    {
        (int n, int d) = CheckedRationalOperations.Multiply(1, 1, -1, 1);
        Assert.Equal(-1, n);
        Assert.Equal(1, d);
    }

    [Fact]
    public void Unchecked_Multiply_one_by_negative_one_returns_negative_one()
    {
        (int n, int d) = UncheckedRationalOperations.Multiply(1, 1, -1, 1);
        Assert.Equal(-1, n);
        Assert.Equal(1, d);
    }

    [Fact]
    public void Checked_Reciprocal_returns_swapped_numerator_and_denominator()
    {
        (int n, int d) = CheckedRationalOperations.Reciprocal(2, 3);
        Assert.Equal(3, n);
        Assert.Equal(2, d);
    }

    [Fact]
    public void Unchecked_Reciprocal_returns_swapped_numerator_and_denominator()
    {
        (int n, int d) = UncheckedRationalOperations.Reciprocal(2, 3);
        Assert.Equal(3, n);
        Assert.Equal(2, d);
    }

    [Fact]
    public void Checked_Reciprocal_with_negative_numerator_normalizes_sign()
    {
        (int n, int d) = CheckedRationalOperations.Reciprocal(-2, 3);
        Assert.Equal(-3, n);
        Assert.Equal(2, d);
    }

    [Fact]
    public void Unchecked_Reciprocal_with_negative_numerator_normalizes_sign()
    {
        (int n, int d) = UncheckedRationalOperations.Reciprocal(-2, 3);
        Assert.Equal(-3, n);
        Assert.Equal(2, d);
    }

    [Fact]
    public void Checked_Reciprocal_with_numerator_zero_throws()
    {
        var ex = Assert.Throws<ArgumentOutOfRangeException>(() => CheckedRationalOperations.Reciprocal(0, 3));
        Assert.Equal("numerator", ex.ParamName);
    }

    [Fact]
    public void Unchecked_Reciprocal_with_numerator_zero_throws()
    {
        var ex = Assert.Throws<ArgumentOutOfRangeException>(() => UncheckedRationalOperations.Reciprocal(0, 3));
        Assert.Equal("numerator", ex.ParamName);
    }

    [Fact]
    public void Checked_Reciprocal_overflow_throws()
        => Assert.Throws<OverflowException>(() => CheckedRationalOperations.Reciprocal(int.MinValue, 1));

    [Fact]
    public void Unchecked_Reciprocal_overflow_wraps()
    {
        (int n, int d) = UncheckedRationalOperations.Reciprocal(int.MinValue, 1);
        Assert.Equal(-1, n);
        Assert.Equal(int.MinValue, d);
    }
}
