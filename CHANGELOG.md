# Changelog

## [Unreleased] - 2026-01-15

### Added

- Algorithms.Specialized: `CheckedRationalOperations.Reciprocal` and `UncheckedRationalOperations.Reciprocal`
- Rational: Integer factory overloads `Rational.Create<T>(T numerator)` and `BigIntegerRational.Create(BigInteger numerator)`
- Rational: Utility methods `Rational.Abs`, `Rational.IsInteger`, `Rational.IsNegative`, `Rational.IsPositive`, `Rational.IsZero`

### Changed

- Rational: `BigIntegerRational` is now included in `Ratiocinia.Rational` (project/package layout change)

### Removed

- BigIntegerRational: Standalone `Ratiocinia.BigIntegerRational` project/package (moved into `Ratiocinia.Rational`)

## [0.1.2] - 2026-01-15

### Added

- Algorithms.Generic: `RationalOperations.Reciprocal` for computing a rational multiplicative inverse

### Fixed

- Algorithms.Generic: Correct GCD reduction in `RationalOperations.Multiply` and `RationalOperations.Divide`

## [0.1.1] - 2026-01-14

### Added

- Abstractions: Pure interfaces for math operations (`IAdditionFunctions<T>`, `IDivisionFunctions<T>`, etc.)
- Algorithms.Generic: Policy-based rational arithmetic algorithms via `RationalOperations` class
- Models: Checked and unchecked arithmetic policy implementations
- Algorithms.Specialized: Convenience wrappers `CheckedRationalOperations`, `UncheckedRationalOperations`, `NumericRationalOperations`
- BigIntegerRational: Non-generic `BigIntegerRational` struct for arbitrary precision
- Rational: Generic `Rational<T>` struct for any `IBinaryInteger<T>` type

[Unreleased]: https://github.com/qbit86/ratiocinia/compare/v0.1.2-algorithms.generic...HEAD

[0.1.2]: https://github.com/qbit86/ratiocinia/compare/v0.1.1-rational...v0.1.2-algorithms.generic

[0.1.1]: https://github.com/qbit86/ratiocinia/releases/tag/v0.1.1-rational
