using System;
using System.Globalization;

namespace Ratiocinia;

public sealed class RationalTests
{
    #region Factory Methods

    [Fact]
    public void Create_normalizes_fraction()
    {
        var r = Rational.Create(2, 4);
        Assert.Equal(1, r.Numerator);
        Assert.Equal(2, r.Denominator);
    }

    [Fact]
    public void Create_normalizes_sign_to_numerator()
    {
        var r = Rational.Create(1, -2);
        Assert.Equal(-1, r.Numerator);
        Assert.Equal(2, r.Denominator);
    }

    [Fact]
    public void Create_with_zero_denominator_throws() =>
        Assert.Throws<ArgumentOutOfRangeException>(() => Rational.Create(1, 0));

    [Fact]
    public void TryCreate_with_normalized_values_returns_true()
    {
        bool result = Rational.TryCreate(1, 2, out var r);
        Assert.True(result);
        Assert.Equal(1, r.Numerator);
        Assert.Equal(2, r.Denominator);
    }

    [Fact]
    public void TryCreate_with_non_normalized_values_returns_false()
    {
        bool result = Rational.TryCreate(2, 4, out var r);
        Assert.False(result);
        Assert.Equal(0, r.Numerator);
        Assert.Equal(1, r.Denominator);
    }

    [Fact]
    public void Create_with_single_value_creates_integer_rational()
    {
        var r = Rational.Create(5);
        Assert.Equal(5, r.Numerator);
        Assert.Equal(1, r.Denominator);
    }

    [Fact]
    public void Create_with_single_negative_value_creates_integer_rational()
    {
        var r = Rational.Create(-3);
        Assert.Equal(-3, r.Numerator);
        Assert.Equal(1, r.Denominator);
    }

    [Fact]
    public void Create_with_single_zero_value_creates_zero_rational()
    {
        var r = Rational.Create(0);
        Assert.Equal(0, r.Numerator);
        Assert.Equal(1, r.Denominator);
    }

    [Fact]
    public void RationalT_Create_with_single_value_creates_integer_rational()
    {
        var r = Rational<int>.Create(7);
        Assert.Equal(7, r.Numerator);
        Assert.Equal(1, r.Denominator);
    }

    #endregion

    #region Default Value

    [Fact]
    public void Default_value_is_zero()
    {
        Rational<int> r = default;
        Assert.Equal(0, r.Numerator);
        Assert.Equal(1, r.Denominator);
    }

    [Fact]
    public void Default_value_equals_zero()
    {
        Rational<int> r = default;
        Assert.Equal(Rational<int>.Zero, r);
    }

    [Fact]
    public void Default_value_is_additive_identity()
    {
        Rational<int> r = default;
        Assert.Equal(Rational<int>.AdditiveIdentity, r);
    }

    #endregion

    #region Arithmetic Operators

    [Fact]
    public void Addition_operator_adds_fractions()
    {
        var a = Rational.Create(1, 2);
        var b = Rational.Create(1, 3);
        var result = a + b;
        Assert.Equal(5, result.Numerator);
        Assert.Equal(6, result.Denominator);
    }

    [Fact]
    public void Addition_operator_reduces_result()
    {
        var a = Rational.Create(1, 2);
        var b = Rational.Create(1, 2);
        var result = a + b;
        Assert.Equal(1, result.Numerator);
        Assert.Equal(1, result.Denominator);
    }

    [Fact]
    public void Subtraction_operator_subtracts_fractions()
    {
        var a = Rational.Create(1, 2);
        var b = Rational.Create(1, 3);
        var result = a - b;
        Assert.Equal(1, result.Numerator);
        Assert.Equal(6, result.Denominator);
    }

    [Fact]
    public void Subtraction_operator_handles_negative_result()
    {
        var a = Rational.Create(1, 3);
        var b = Rational.Create(1, 2);
        var result = a - b;
        Assert.Equal(-1, result.Numerator);
        Assert.Equal(6, result.Denominator);
    }

    [Fact]
    public void Multiplication_operator_multiplies_fractions()
    {
        var a = Rational.Create(2, 3);
        var b = Rational.Create(3, 4);
        var result = a * b;
        Assert.Equal(1, result.Numerator);
        Assert.Equal(2, result.Denominator);
    }

    [Fact]
    public void Division_operator_divides_fractions()
    {
        var a = Rational.Create(1, 2);
        var b = Rational.Create(3, 4);
        var result = a / b;
        Assert.Equal(2, result.Numerator);
        Assert.Equal(3, result.Denominator);
    }

    [Fact]
    public void Division_by_zero_throws()
    {
        var a = Rational.Create(1, 2);
        var b = Rational<int>.Zero;
        Assert.Throws<ArgumentOutOfRangeException>(() => a / b);
    }

    [Fact]
    public void Unary_negation_operator_negates_fraction()
    {
        var a = Rational.Create(1, 2);
        var result = -a;
        Assert.Equal(-1, result.Numerator);
        Assert.Equal(2, result.Denominator);
    }

    [Fact]
    public void Unary_plus_operator_returns_same_value()
    {
        var a = Rational.Create(1, 2);
        var result = +a;
        Assert.Equal(a, result);
    }

    [Fact]
    public void Increment_operator_adds_one()
    {
        var a = Rational.Create(1, 2);
        var result = ++a;
        Assert.Equal(3, result.Numerator);
        Assert.Equal(2, result.Denominator);
    }

    [Fact]
    public void Decrement_operator_subtracts_one()
    {
        var a = Rational.Create(3, 2);
        var result = --a;
        Assert.Equal(1, result.Numerator);
        Assert.Equal(2, result.Denominator);
    }

    #endregion

    #region Checked vs Unchecked Operators

    [Fact]
    public void Checked_addition_overflow_throws()
    {
        var a = Rational.Create(int.MaxValue, 1);
        var b = Rational.Create(1, 1);
        Assert.Throws<OverflowException>(() => checked(a + b));
    }

    [Fact]
    public void Unchecked_addition_overflow_wraps()
    {
        var a = Rational.Create(int.MaxValue, 1);
        var b = Rational.Create(1, 1);
        var result = unchecked(a + b);
        Assert.Equal(int.MinValue, result.Numerator);
        Assert.Equal(1, result.Denominator);
    }

    [Fact]
    public void Checked_subtraction_overflow_throws()
    {
        var a = Rational.Create(int.MinValue, 1);
        var b = Rational.Create(1, 1);
        Assert.Throws<OverflowException>(() => checked(a - b));
    }

    [Fact]
    public void Checked_multiplication_overflow_throws()
    {
        var a = Rational.Create(int.MaxValue, 1);
        var b = Rational.Create(2, 1);
        Assert.Throws<OverflowException>(() => checked(a * b));
    }

    [Fact]
    public void Checked_negation_overflow_throws()
    {
        var a = Rational.Create(int.MinValue, 1);
        Assert.Throws<OverflowException>(() => checked(-a));
    }

    [Fact]
    public void Unchecked_negation_overflow_wraps()
    {
        var a = Rational.Create(int.MinValue, 1);
        var result = unchecked(-a);
        Assert.Equal(int.MinValue, result.Numerator);
        Assert.Equal(1, result.Denominator);
    }

    #endregion

    #region Comparison Operators

    [Fact]
    public void Equality_operator_returns_true_for_equal_values()
    {
        var a = Rational.Create(1, 2);
        var b = Rational.Create(2, 4);
        Assert.True(a == b);
    }

    [Fact]
    public void Inequality_operator_returns_true_for_different_values()
    {
        var a = Rational.Create(1, 2);
        var b = Rational.Create(1, 3);
        Assert.True(a != b);
    }

    [Fact]
    public void LessThan_operator_compares_correctly()
    {
        var a = Rational.Create(1, 3);
        var b = Rational.Create(1, 2);
        Assert.True(a < b);
        Assert.False(b < a);
    }

    [Fact]
    public void LessThanOrEqual_operator_compares_correctly()
    {
        var a = Rational.Create(1, 2);
        var b = Rational.Create(1, 2);
        var c = Rational.Create(2, 3);
        Assert.True(a <= b);
        Assert.True(a <= c);
        Assert.False(c <= a);
    }

    [Fact]
    public void GreaterThan_operator_compares_correctly()
    {
        var a = Rational.Create(1, 2);
        var b = Rational.Create(1, 3);
        Assert.True(a > b);
        Assert.False(b > a);
    }

    [Fact]
    public void GreaterThanOrEqual_operator_compares_correctly()
    {
        var a = Rational.Create(1, 2);
        var b = Rational.Create(1, 2);
        var c = Rational.Create(1, 3);
        Assert.True(a >= b);
        Assert.True(a >= c);
        Assert.False(c >= a);
    }

    [Fact]
    public void CompareTo_returns_correct_ordering()
    {
        var a = Rational.Create(1, 3);
        var b = Rational.Create(1, 2);
        var c = Rational.Create(1, 2);
        Assert.True(a.CompareTo(b) < 0);
        Assert.True(b.CompareTo(a) > 0);
        Assert.Equal(0, b.CompareTo(c));
    }

    #endregion

    #region INumberBase Methods

    [Fact]
    public void Abs_returns_absolute_value()
    {
        var negative = Rational.Create(-1, 2);
        var positive = Rational.Create(1, 2);
        Assert.Equal(positive, Rational<int>.Abs(negative));
        Assert.Equal(positive, Rational<int>.Abs(positive));
    }

    [Fact]
    public void IsZero_returns_true_for_zero()
    {
        Assert.True(Rational<int>.IsZero(Rational<int>.Zero));
        Assert.True(Rational<int>.IsZero(default));
        Assert.False(Rational<int>.IsZero(Rational<int>.One));
    }

    [Fact]
    public void IsNegative_returns_true_for_negative_values()
    {
        var negative = Rational.Create(-1, 2);
        var positive = Rational.Create(1, 2);
        Assert.True(Rational<int>.IsNegative(negative));
        Assert.False(Rational<int>.IsNegative(positive));
        Assert.False(Rational<int>.IsNegative(Rational<int>.Zero));
    }

    [Fact]
    public void IsPositive_returns_true_for_positive_values()
    {
        var negative = Rational.Create(-1, 2);
        var positive = Rational.Create(1, 2);
        Assert.False(Rational<int>.IsPositive(negative));
        Assert.True(Rational<int>.IsPositive(positive));
        Assert.False(Rational<int>.IsPositive(Rational<int>.Zero));
    }

    [Fact]
    public void IsInteger_returns_true_for_integer_values()
    {
        var integer = Rational.Create(4, 2);
        var nonInteger = Rational.Create(1, 2);
        Assert.True(Rational<int>.IsInteger(integer));
        Assert.False(Rational<int>.IsInteger(nonInteger));
    }

    [Fact]
    public void IsEvenInteger_returns_true_for_even_integers()
    {
        var even = Rational.Create(4, 1);
        var odd = Rational.Create(3, 1);
        var nonInteger = Rational.Create(1, 2);
        Assert.True(Rational<int>.IsEvenInteger(even));
        Assert.False(Rational<int>.IsEvenInteger(odd));
        Assert.False(Rational<int>.IsEvenInteger(nonInteger));
    }

    [Fact]
    public void IsOddInteger_returns_true_for_odd_integers()
    {
        var even = Rational.Create(4, 1);
        var odd = Rational.Create(3, 1);
        var nonInteger = Rational.Create(1, 2);
        Assert.False(Rational<int>.IsOddInteger(even));
        Assert.True(Rational<int>.IsOddInteger(odd));
        Assert.False(Rational<int>.IsOddInteger(nonInteger));
    }

    [Fact]
    public void IsNormal_returns_true_for_non_zero_values()
    {
        Assert.True(Rational<int>.IsNormal(Rational<int>.One));
        Assert.False(Rational<int>.IsNormal(Rational<int>.Zero));
    }

    [Fact]
    public void MaxMagnitude_returns_value_with_larger_absolute_value()
    {
        var a = Rational.Create(-3, 2);
        var b = Rational.Create(1, 2);
        Assert.Equal(a, Rational<int>.MaxMagnitude(a, b));
    }

    [Fact]
    public void MinMagnitude_returns_value_with_smaller_absolute_value()
    {
        var a = Rational.Create(-3, 2);
        var b = Rational.Create(1, 2);
        Assert.Equal(b, Rational<int>.MinMagnitude(a, b));
    }

    [Fact]
    public void One_is_multiplicative_identity()
    {
        Assert.Equal(Rational<int>.MultiplicativeIdentity, Rational<int>.One);
        Assert.Equal(1, Rational<int>.One.Numerator);
        Assert.Equal(1, Rational<int>.One.Denominator);
    }

    [Fact]
    public void Zero_is_additive_identity()
    {
        Assert.Equal(Rational<int>.AdditiveIdentity, Rational<int>.Zero);
        Assert.Equal(0, Rational<int>.Zero.Numerator);
        Assert.Equal(1, Rational<int>.Zero.Denominator);
    }

    #endregion

    #region Parsing

    [Fact]
    public void Parse_parses_fraction_string()
    {
        var r = Rational<int>.Parse("3/4", CultureInfo.InvariantCulture);
        Assert.Equal(3, r.Numerator);
        Assert.Equal(4, r.Denominator);
    }

    [Fact]
    public void Parse_parses_integer_string()
    {
        var r = Rational<int>.Parse("5", CultureInfo.InvariantCulture);
        Assert.Equal(5, r.Numerator);
        Assert.Equal(1, r.Denominator);
    }

    [Fact]
    public void Parse_normalizes_result()
    {
        var r = Rational<int>.Parse("2/4", CultureInfo.InvariantCulture);
        Assert.Equal(1, r.Numerator);
        Assert.Equal(2, r.Denominator);
    }

    [Fact]
    public void Parse_handles_negative_numerator()
    {
        var r = Rational<int>.Parse("-3/4", CultureInfo.InvariantCulture);
        Assert.Equal(-3, r.Numerator);
        Assert.Equal(4, r.Denominator);
    }

    [Fact]
    public void Parse_with_invalid_format_throws() =>
        Assert.Throws<FormatException>(() => Rational<int>.Parse("invalid", CultureInfo.InvariantCulture));

    [Fact]
    public void Parse_with_zero_denominator_throws() =>
        Assert.Throws<FormatException>(() => Rational<int>.Parse("1/0", CultureInfo.InvariantCulture));

    [Fact]
    public void TryParse_returns_true_for_valid_input()
    {
        bool result = Rational<int>.TryParse("3/4", CultureInfo.InvariantCulture, out var r);
        Assert.True(result);
        Assert.Equal(3, r.Numerator);
        Assert.Equal(4, r.Denominator);
    }

    [Fact]
    public void TryParse_returns_false_for_invalid_input()
    {
        bool result = Rational<int>.TryParse("invalid", CultureInfo.InvariantCulture, out var r);
        Assert.False(result);
        Assert.Equal(Rational<int>.Zero, r);
    }

    [Fact]
    public void TryParse_returns_false_for_zero_denominator()
    {
        bool result = Rational<int>.TryParse("1/0", CultureInfo.InvariantCulture, out var r);
        Assert.False(result);
        Assert.Equal(Rational<int>.Zero, r);
    }

    #endregion

    #region Formatting

    [Fact]
    public void ToString_returns_fraction_format()
    {
        var r = Rational.Create(3, 4);
        Assert.Equal("3/4", r.ToString());
    }

    [Fact]
    public void ToString_with_format_applies_to_components()
    {
        var r = Rational.Create(1000, 2000);
        string result = r.ToString("N0", CultureInfo.InvariantCulture);
        Assert.Equal("1/2", result);
    }

    [Fact]
    public void TryFormat_formats_to_span()
    {
        var r = Rational.Create(3, 4);
        Span<char> buffer = stackalloc char[10];
        bool success = r.TryFormat(buffer, out int charsWritten, default, CultureInfo.InvariantCulture);
        Assert.True(success);
        Assert.Equal("3/4", buffer[..charsWritten].ToString());
    }

    [Fact]
    public void TryFormat_returns_false_when_buffer_too_small()
    {
        var r = Rational.Create(123, 456);
        Span<char> buffer = stackalloc char[3];
        bool success = r.TryFormat(buffer, out int _, default, CultureInfo.InvariantCulture);
        Assert.False(success);
    }

    #endregion

    #region Equality and HashCode

    [Fact]
    public void Equals_returns_true_for_equal_values()
    {
        var a = Rational.Create(1, 2);
        var b = Rational.Create(2, 4);
        Assert.True(a.Equals(b));
        Assert.True(a.Equals((object)b));
    }

    [Fact]
    public void Equals_returns_false_for_different_values()
    {
        var a = Rational.Create(1, 2);
        var b = Rational.Create(1, 3);
        Assert.False(a.Equals(b));
        Assert.False(a.Equals((object)b));
    }

    [Fact]
    public void Equals_returns_false_for_null()
    {
        var a = Rational.Create(1, 2);
        Assert.False(a.Equals(null));
    }

    [Fact]
    public void GetHashCode_returns_same_value_for_equal_rationals()
    {
        var a = Rational.Create(1, 2);
        var b = Rational.Create(2, 4);
        Assert.Equal(a.GetHashCode(), b.GetHashCode());
    }

    #endregion

    #region Different Underlying Types

    [Fact]
    public void Works_with_long_type()
    {
        var a = Rational.Create(1L, 2L);
        var b = Rational.Create(1L, 3L);
        var result = a + b;
        Assert.Equal(5L, result.Numerator);
        Assert.Equal(6L, result.Denominator);
    }

    [Fact]
    public void Works_with_short_type()
    {
        var a = Rational<short>.Create(1, 2);
        var b = Rational<short>.Create(1, 3);
        var result = a + b;
        Assert.Equal((short)5, result.Numerator);
        Assert.Equal((short)6, result.Denominator);
    }

    #endregion

    #region Deconstruct

    [Fact]
    public void Deconstruct_returns_numerator_and_denominator()
    {
        var r = Rational.Create(3, 4);
        (int numerator, int denominator) = r;
        Assert.Equal(3, numerator);
        Assert.Equal(4, denominator);
    }

    [Fact]
    public void Deconstruct_returns_normalized_values()
    {
        var r = Rational.Create(6, 8);
        (int numerator, int denominator) = r;
        Assert.Equal(3, numerator);
        Assert.Equal(4, denominator);
    }

    [Fact]
    public void Deconstruct_default_value_returns_zero_and_one()
    {
        Rational<int> r = default;
        (int numerator, int denominator) = r;
        Assert.Equal(0, numerator);
        Assert.Equal(1, denominator);
    }

    #endregion
}
