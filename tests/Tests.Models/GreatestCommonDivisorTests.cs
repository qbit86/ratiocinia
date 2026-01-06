using System;
using System.Numerics;
using Ratiocinia.Models;

namespace Ratiocinia;

public sealed class GreatestCommonDivisorTests
{
    public static TheoryData<int, int, int> Int32Cases { get; } = new()
    {
        { 48, 18, 6 },
        { 18, 48, 6 },
        { 5, 0, 5 },
        { 0, 5, 5 },
        { 0, 0, 0 }
    };

    [Theory]
    [MemberData(nameof(Int32Cases))]
    public void GcdEquatable_int_returns_expected(int left, int right, int expected)
        => Assert.Equal(expected, GreatestCommonDivisor.GcdEquatable(left, right));

    [Theory]
    [MemberData(nameof(Int32Cases))]
    public void GcdComparable_int_returns_expected(int left, int right, int expected)
        => Assert.Equal(expected, GreatestCommonDivisor.GcdComparable(left, right));

    [Theory]
    [MemberData(nameof(Int32Cases))]
    public void GcdNumberBase_int_returns_expected(int left, int right, int expected)
        => Assert.Equal(expected, GreatestCommonDivisor.GcdNumberBase(left, right));

    [Fact]
    public void GcdEquatable_int_sign_matches_euclidean_iteration()
    {
        // For signed inputs, we only guarantee the *magnitude* and divisibility, not a specific sign.
        AssertGcdMagnitudeAndDivisibility(-48, 18, 6);
        AssertGcdMagnitudeAndDivisibility(48, -18, 6);
        AssertGcdMagnitudeAndDivisibility(-48, -18, 6);
    }

    [Fact]
    public void GcdNumberBase_BigInteger_returns_expected()
    {
        BigInteger left = new(48);
        BigInteger right = new(18);

        Assert.Equal(new BigInteger(6), GreatestCommonDivisor.GcdNumberBase(left, right));
    }

    [Fact]
    public void GcdEquatable_uses_supplied_identity_equatable()
    {
        // If "right" is considered the identity, the algorithm returns "left" immediately.
        int result = GreatestCommonDivisor.GcdEquatable(10, 6, new TreatSixAsIdentityEquatable());
        Assert.Equal(10, result);
    }

    [Fact]
    public void GcdComparable_uses_supplied_identity_comparable()
    {
        // If "right" compares equal to the identity, the algorithm returns "left" immediately.
        int result = GreatestCommonDivisor.GcdComparable(10, 6, new TreatSixAsIdentityComparable());
        Assert.Equal(10, result);
    }

    private static void AssertGcdMagnitudeAndDivisibility(int left, int right, int expectedMagnitude)
    {
        int gcd = GreatestCommonDivisor.GcdEquatable(left, right);

        Assert.Equal(expectedMagnitude, Math.Abs(gcd));

        // Using gcd's sign as-is: divisibility should still hold.
        Assert.Equal(0, left % gcd);
        Assert.Equal(0, right % gcd);
    }

    private readonly struct TreatSixAsIdentityEquatable : IEquatable<int>
    {
        public bool Equals(int other) => other is 6;
    }

    private readonly struct TreatSixAsIdentityComparable : IComparable<int>
    {
        public int CompareTo(int other) => other is 6 ? 0 : 1;
    }
}
