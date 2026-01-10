using System;
using System.Globalization;
using System.Numerics;

namespace Ratiocinia;

internal static class Program
{
    private static void Main()
    {
        // === Using Rational<T> ===

        // Create rational numbers (automatically normalized)
        var half = Rational.Create(1, 2);
        var third = Rational.Create(1, 3);

        // Arithmetic operations
        var sum = half + third; // 5/6
        var product = half * third; // 1/6
        var quotient = half / third; // 3/2

        // Checked arithmetic (throws on overflow)
        var result = checked(half + third);

        // Comparisons
        bool isLess = half < third; // false
        bool isEqual = half.Equals(half); // true

        // INumberBase methods
        bool isInteger = Rational<int>.IsInteger(half); // false
        bool isZero = Rational<int>.IsZero(half); // false
        bool isPositive = Rational<int>.IsPositive(half); // true

        Console.WriteLine("=== Rational<int> Examples ===");
        Console.WriteLine($"half = {half}");
        Console.WriteLine($"third = {third}");
        Console.WriteLine($"half + third = {sum}");
        Console.WriteLine($"half * third = {product}");
        Console.WriteLine($"half / third = {quotient}");
        Console.WriteLine($"checked(half + third) = {result}");
        Console.WriteLine($"half < third = {isLess}");
        Console.WriteLine($"half == half = {isEqual}");
        Console.WriteLine($"IsInteger(half) = {isInteger}");
        Console.WriteLine($"IsZero(half) = {isZero}");
        Console.WriteLine($"IsPositive(half) = {isPositive}");

        // === Using BigIntegerRational ===

        // Create from BigInteger values
        var large = BigIntegerRational.Create(
            BigInteger.Parse("123456789012345678901234567890", CultureInfo.InvariantCulture),
            BigInteger.Parse("987654321098765432109876543210", CultureInfo.InvariantCulture)
        );

        // Or from smaller integers
        var simple = BigIntegerRational.Create(22, 7);

        // Full arithmetic support
        var bigSum = large + simple;
        var bigProduct = large * simple;

        Console.WriteLine();
        Console.WriteLine("=== BigIntegerRational Examples ===");
        Console.WriteLine($"large = {large}");
        Console.WriteLine($"simple = {simple}");
        Console.WriteLine($"large + simple = {bigSum}");
        Console.WriteLine($"large * simple = {bigProduct}");
    }
}
