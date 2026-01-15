using System;
using System.Globalization;
using System.Numerics;

namespace Ratiocinia;

public sealed class BigIntegerRationalTests
{
    #region Factory Methods

    [Fact]
    public void Create_normalizes_fraction()
    {
        var r = BigIntegerRational.Create(2, 4);
        Assert.Equal(BigInteger.One, r.Numerator);
        Assert.Equal(new BigInteger(2), r.Denominator);
    }

    [Fact]
    public void Create_normalizes_sign_to_numerator()
    {
        var r = BigIntegerRational.Create(1, -2);
        Assert.Equal(new BigInteger(-1), r.Numerator);
        Assert.Equal(new BigInteger(2), r.Denominator);
    }

    [Fact]
    public void Create_with_zero_denominator_throws() =>
        Assert.Throws<ArgumentOutOfRangeException>(() => BigIntegerRational.Create(1, 0));

    [Fact]
    public void TryCreate_with_normalized_values_returns_true()
    {
        bool result = BigIntegerRational.TryCreate(1, 2, out var r);
        Assert.True(result);
        Assert.Equal(BigInteger.One, r.Numerator);
        Assert.Equal(new BigInteger(2), r.Denominator);
    }

    [Fact]
    public void TryCreate_with_non_normalized_values_returns_false()
    {
        bool result = BigIntegerRational.TryCreate(2, 4, out var r);
        Assert.False(result);
        Assert.Equal(BigInteger.Zero, r.Numerator);
        Assert.Equal(BigInteger.One, r.Denominator);
    }

    [Fact]
    public void Create_with_single_value_creates_integer_rational()
    {
        var r = BigIntegerRational.Create(5);
        Assert.Equal(new BigInteger(5), r.Numerator);
        Assert.Equal(BigInteger.One, r.Denominator);
    }

    [Fact]
    public void Create_with_single_negative_value_creates_integer_rational()
    {
        var r = BigIntegerRational.Create(-3);
        Assert.Equal(new BigInteger(-3), r.Numerator);
        Assert.Equal(BigInteger.One, r.Denominator);
    }

    [Fact]
    public void Create_with_single_zero_value_creates_zero_rational()
    {
        var r = BigIntegerRational.Create(BigInteger.Zero);
        Assert.Equal(BigInteger.Zero, r.Numerator);
        Assert.Equal(BigInteger.One, r.Denominator);
    }

    #endregion

    #region Default Value

    [Fact]
    public void Default_value_is_zero()
    {
        BigIntegerRational r = default;
        Assert.Equal(BigInteger.Zero, r.Numerator);
        Assert.Equal(BigInteger.One, r.Denominator);
    }

    [Fact]
    public void Default_value_equals_zero()
    {
        BigIntegerRational r = default;
        Assert.Equal(BigIntegerRational.Zero, r);
    }

    [Fact]
    public void Default_value_is_additive_identity()
    {
        BigIntegerRational r = default;
        Assert.Equal(BigIntegerRational.AdditiveIdentity, r);
    }

    #endregion

    #region Arithmetic Operators

    [Fact]
    public void Addition_operator_adds_fractions()
    {
        var a = BigIntegerRational.Create(1, 2);
        var b = BigIntegerRational.Create(1, 3);
        var result = a + b;
        Assert.Equal(new BigInteger(5), result.Numerator);
        Assert.Equal(new BigInteger(6), result.Denominator);
    }

    [Fact]
    public void Addition_operator_reduces_result()
    {
        var a = BigIntegerRational.Create(1, 2);
        var b = BigIntegerRational.Create(1, 2);
        var result = a + b;
        Assert.Equal(BigInteger.One, result.Numerator);
        Assert.Equal(BigInteger.One, result.Denominator);
    }

    [Fact]
    public void Subtraction_operator_subtracts_fractions()
    {
        var a = BigIntegerRational.Create(1, 2);
        var b = BigIntegerRational.Create(1, 3);
        var result = a - b;
        Assert.Equal(BigInteger.One, result.Numerator);
        Assert.Equal(new BigInteger(6), result.Denominator);
    }

    [Fact]
    public void Subtraction_operator_handles_negative_result()
    {
        var a = BigIntegerRational.Create(1, 3);
        var b = BigIntegerRational.Create(1, 2);
        var result = a - b;
        Assert.Equal(new BigInteger(-1), result.Numerator);
        Assert.Equal(new BigInteger(6), result.Denominator);
    }

    [Fact]
    public void Multiplication_operator_multiplies_fractions()
    {
        var a = BigIntegerRational.Create(2, 3);
        var b = BigIntegerRational.Create(3, 4);
        var result = a * b;
        Assert.Equal(BigInteger.One, result.Numerator);
        Assert.Equal(new BigInteger(2), result.Denominator);
    }

    [Fact]
    public void Division_operator_divides_fractions()
    {
        var a = BigIntegerRational.Create(1, 2);
        var b = BigIntegerRational.Create(3, 4);
        var result = a / b;
        Assert.Equal(new BigInteger(2), result.Numerator);
        Assert.Equal(new BigInteger(3), result.Denominator);
    }

    [Fact]
    public void Division_by_zero_throws()
    {
        var a = BigIntegerRational.Create(1, 2);
        var b = BigIntegerRational.Zero;
        Assert.Throws<ArgumentOutOfRangeException>(() => a / b);
    }

    [Fact]
    public void Unary_negation_operator_negates_fraction()
    {
        var a = BigIntegerRational.Create(1, 2);
        var result = -a;
        Assert.Equal(new BigInteger(-1), result.Numerator);
        Assert.Equal(new BigInteger(2), result.Denominator);
    }

    [Fact]
    public void Unary_plus_operator_returns_same_value()
    {
        var a = BigIntegerRational.Create(1, 2);
        var result = +a;
        Assert.Equal(a, result);
    }

    [Fact]
    public void Increment_operator_adds_one()
    {
        var a = BigIntegerRational.Create(1, 2);
        var result = ++a;
        Assert.Equal(new BigInteger(3), result.Numerator);
        Assert.Equal(new BigInteger(2), result.Denominator);
    }

    [Fact]
    public void Decrement_operator_subtracts_one()
    {
        var a = BigIntegerRational.Create(3, 2);
        var result = --a;
        Assert.Equal(BigInteger.One, result.Numerator);
        Assert.Equal(new BigInteger(2), result.Denominator);
    }

    #endregion

    #region Comparison Operators

    [Fact]
    public void Equality_operator_returns_true_for_equal_values()
    {
        var a = BigIntegerRational.Create(1, 2);
        var b = BigIntegerRational.Create(2, 4);
        Assert.True(a == b);
    }

    [Fact]
    public void Inequality_operator_returns_true_for_different_values()
    {
        var a = BigIntegerRational.Create(1, 2);
        var b = BigIntegerRational.Create(1, 3);
        Assert.True(a != b);
    }

    [Fact]
    public void LessThan_operator_compares_correctly()
    {
        var a = BigIntegerRational.Create(1, 3);
        var b = BigIntegerRational.Create(1, 2);
        Assert.True(a < b);
        Assert.False(b < a);
    }

    [Fact]
    public void LessThanOrEqual_operator_compares_correctly()
    {
        var a = BigIntegerRational.Create(1, 2);
        var b = BigIntegerRational.Create(1, 2);
        var c = BigIntegerRational.Create(2, 3);
        Assert.True(a <= b);
        Assert.True(a <= c);
        Assert.False(c <= a);
    }

    [Fact]
    public void GreaterThan_operator_compares_correctly()
    {
        var a = BigIntegerRational.Create(1, 2);
        var b = BigIntegerRational.Create(1, 3);
        Assert.True(a > b);
        Assert.False(b > a);
    }

    [Fact]
    public void GreaterThanOrEqual_operator_compares_correctly()
    {
        var a = BigIntegerRational.Create(1, 2);
        var b = BigIntegerRational.Create(1, 2);
        var c = BigIntegerRational.Create(1, 3);
        Assert.True(a >= b);
        Assert.True(a >= c);
        Assert.False(c >= a);
    }

    [Fact]
    public void CompareTo_returns_correct_ordering()
    {
        var a = BigIntegerRational.Create(1, 3);
        var b = BigIntegerRational.Create(1, 2);
        var c = BigIntegerRational.Create(1, 2);
        Assert.True(a.CompareTo(b) < 0);
        Assert.True(b.CompareTo(a) > 0);
        Assert.Equal(0, b.CompareTo(c));
    }

    #endregion

    #region INumberBase Methods

    [Fact]
    public void Abs_returns_absolute_value()
    {
        var negative = BigIntegerRational.Create(-1, 2);
        var positive = BigIntegerRational.Create(1, 2);
        Assert.Equal(positive, BigIntegerRational.Abs(negative));
        Assert.Equal(positive, BigIntegerRational.Abs(positive));
    }

    [Fact]
    public void IsZero_returns_true_for_zero()
    {
        Assert.True(BigIntegerRational.IsZero(BigIntegerRational.Zero));
        Assert.True(BigIntegerRational.IsZero(default));
        Assert.False(BigIntegerRational.IsZero(BigIntegerRational.One));
    }

    [Fact]
    public void IsNegative_returns_true_for_negative_values()
    {
        var negative = BigIntegerRational.Create(-1, 2);
        var positive = BigIntegerRational.Create(1, 2);
        Assert.True(BigIntegerRational.IsNegative(negative));
        Assert.False(BigIntegerRational.IsNegative(positive));
        Assert.False(BigIntegerRational.IsNegative(BigIntegerRational.Zero));
    }

    [Fact]
    public void IsPositive_returns_true_for_positive_values()
    {
        var negative = BigIntegerRational.Create(-1, 2);
        var positive = BigIntegerRational.Create(1, 2);
        Assert.False(BigIntegerRational.IsPositive(negative));
        Assert.True(BigIntegerRational.IsPositive(positive));
        Assert.False(BigIntegerRational.IsPositive(BigIntegerRational.Zero));
    }

    [Fact]
    public void IsInteger_returns_true_for_integer_values()
    {
        var integer = BigIntegerRational.Create(4, 2);
        var nonInteger = BigIntegerRational.Create(1, 2);
        Assert.True(BigIntegerRational.IsInteger(integer));
        Assert.False(BigIntegerRational.IsInteger(nonInteger));
    }

    [Fact]
    public void IsEvenInteger_returns_true_for_even_integers()
    {
        var even = BigIntegerRational.Create(4, 1);
        var odd = BigIntegerRational.Create(3, 1);
        var nonInteger = BigIntegerRational.Create(1, 2);
        Assert.True(BigIntegerRational.IsEvenInteger(even));
        Assert.False(BigIntegerRational.IsEvenInteger(odd));
        Assert.False(BigIntegerRational.IsEvenInteger(nonInteger));
    }

    [Fact]
    public void IsOddInteger_returns_true_for_odd_integers()
    {
        var even = BigIntegerRational.Create(4, 1);
        var odd = BigIntegerRational.Create(3, 1);
        var nonInteger = BigIntegerRational.Create(1, 2);
        Assert.False(BigIntegerRational.IsOddInteger(even));
        Assert.True(BigIntegerRational.IsOddInteger(odd));
        Assert.False(BigIntegerRational.IsOddInteger(nonInteger));
    }

    [Fact]
    public void IsNormal_returns_true_for_non_zero_values()
    {
        Assert.True(BigIntegerRational.IsNormal(BigIntegerRational.One));
        Assert.False(BigIntegerRational.IsNormal(BigIntegerRational.Zero));
    }

    [Fact]
    public void MaxMagnitude_returns_value_with_larger_absolute_value()
    {
        var a = BigIntegerRational.Create(-3, 2);
        var b = BigIntegerRational.Create(1, 2);
        Assert.Equal(a, BigIntegerRational.MaxMagnitude(a, b));
    }

    [Fact]
    public void MinMagnitude_returns_value_with_smaller_absolute_value()
    {
        var a = BigIntegerRational.Create(-3, 2);
        var b = BigIntegerRational.Create(1, 2);
        Assert.Equal(b, BigIntegerRational.MinMagnitude(a, b));
    }

    [Fact]
    public void One_is_multiplicative_identity()
    {
        Assert.Equal(BigIntegerRational.MultiplicativeIdentity, BigIntegerRational.One);
        Assert.Equal(BigInteger.One, BigIntegerRational.One.Numerator);
        Assert.Equal(BigInteger.One, BigIntegerRational.One.Denominator);
    }

    [Fact]
    public void Zero_is_additive_identity()
    {
        Assert.Equal(BigIntegerRational.AdditiveIdentity, BigIntegerRational.Zero);
        Assert.Equal(BigInteger.Zero, BigIntegerRational.Zero.Numerator);
        Assert.Equal(BigInteger.One, BigIntegerRational.Zero.Denominator);
    }

    #endregion

    #region Parsing

    [Fact]
    public void Parse_parses_fraction_string()
    {
        var r = BigIntegerRational.Parse("3/4", CultureInfo.InvariantCulture);
        Assert.Equal(new BigInteger(3), r.Numerator);
        Assert.Equal(new BigInteger(4), r.Denominator);
    }

    [Fact]
    public void Parse_parses_integer_string()
    {
        var r = BigIntegerRational.Parse("5", CultureInfo.InvariantCulture);
        Assert.Equal(new BigInteger(5), r.Numerator);
        Assert.Equal(BigInteger.One, r.Denominator);
    }

    [Fact]
    public void Parse_normalizes_result()
    {
        var r = BigIntegerRational.Parse("2/4", CultureInfo.InvariantCulture);
        Assert.Equal(BigInteger.One, r.Numerator);
        Assert.Equal(new BigInteger(2), r.Denominator);
    }

    [Fact]
    public void Parse_handles_negative_numerator()
    {
        var r = BigIntegerRational.Parse("-3/4", CultureInfo.InvariantCulture);
        Assert.Equal(new BigInteger(-3), r.Numerator);
        Assert.Equal(new BigInteger(4), r.Denominator);
    }

    [Fact]
    public void Parse_with_invalid_format_throws() =>
        Assert.Throws<FormatException>(() => BigIntegerRational.Parse("invalid", CultureInfo.InvariantCulture));

    [Fact]
    public void Parse_with_zero_denominator_throws() =>
        Assert.Throws<FormatException>(() => BigIntegerRational.Parse("1/0", CultureInfo.InvariantCulture));

    [Fact]
    public void TryParse_returns_true_for_valid_input()
    {
        bool result = BigIntegerRational.TryParse("3/4", CultureInfo.InvariantCulture, out var r);
        Assert.True(result);
        Assert.Equal(new BigInteger(3), r.Numerator);
        Assert.Equal(new BigInteger(4), r.Denominator);
    }

    [Fact]
    public void TryParse_returns_false_for_invalid_input()
    {
        bool result = BigIntegerRational.TryParse("invalid", CultureInfo.InvariantCulture, out var r);
        Assert.False(result);
        Assert.Equal(BigIntegerRational.Zero, r);
    }

    [Fact]
    public void TryParse_returns_false_for_zero_denominator()
    {
        bool result = BigIntegerRational.TryParse("1/0", CultureInfo.InvariantCulture, out var r);
        Assert.False(result);
        Assert.Equal(BigIntegerRational.Zero, r);
    }

    #endregion

    #region Formatting

    [Fact]
    public void ToString_returns_fraction_format()
    {
        var r = BigIntegerRational.Create(3, 4);
        Assert.Equal("3/4", r.ToString());
    }

    [Fact]
    public void ToString_with_format_applies_to_components()
    {
        var r = BigIntegerRational.Create(1000, 2000);
        string result = r.ToString("N0", CultureInfo.InvariantCulture);
        Assert.Equal("1/2", result);
    }

    [Fact]
    public void TryFormat_formats_to_span()
    {
        var r = BigIntegerRational.Create(3, 4);
        Span<char> buffer = stackalloc char[10];
        bool success = r.TryFormat(buffer, out int charsWritten, default, CultureInfo.InvariantCulture);
        Assert.True(success);
        Assert.Equal("3/4", buffer[..charsWritten].ToString());
    }

    [Fact]
    public void TryFormat_returns_false_when_buffer_too_small()
    {
        var r = BigIntegerRational.Create(123, 456);
        Span<char> buffer = stackalloc char[3];
        bool success = r.TryFormat(buffer, out int _, default, CultureInfo.InvariantCulture);
        Assert.False(success);
    }

    #endregion

    #region Equality and HashCode

    [Fact]
    public void Equals_returns_true_for_equal_values()
    {
        var a = BigIntegerRational.Create(1, 2);
        var b = BigIntegerRational.Create(2, 4);
        Assert.True(a.Equals(b));
        Assert.True(a.Equals((object)b));
    }

    [Fact]
    public void Equals_returns_false_for_different_values()
    {
        var a = BigIntegerRational.Create(1, 2);
        var b = BigIntegerRational.Create(1, 3);
        Assert.False(a.Equals(b));
        Assert.False(a.Equals((object)b));
    }

    [Fact]
    public void Equals_returns_false_for_null()
    {
        var a = BigIntegerRational.Create(1, 2);
        Assert.False(a.Equals(null));
    }

    [Fact]
    public void GetHashCode_returns_same_value_for_equal_rationals()
    {
        var a = BigIntegerRational.Create(1, 2);
        var b = BigIntegerRational.Create(2, 4);
        Assert.Equal(a.GetHashCode(), b.GetHashCode());
    }

    #endregion

    #region Deconstruct

    [Fact]
    public void Deconstruct_returns_numerator_and_denominator()
    {
        var r = BigIntegerRational.Create(3, 4);
        var (numerator, denominator) = r;
        Assert.Equal(new BigInteger(3), numerator);
        Assert.Equal(new BigInteger(4), denominator);
    }

    [Fact]
    public void Deconstruct_returns_normalized_values()
    {
        var r = BigIntegerRational.Create(6, 8);
        var (numerator, denominator) = r;
        Assert.Equal(new BigInteger(3), numerator);
        Assert.Equal(new BigInteger(4), denominator);
    }

    [Fact]
    public void Deconstruct_default_value_returns_zero_and_one()
    {
        BigIntegerRational r = default;
        var (numerator, denominator) = r;
        Assert.Equal(BigInteger.Zero, numerator);
        Assert.Equal(BigInteger.One, denominator);
    }

    #endregion
}
