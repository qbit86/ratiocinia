# Changelog

## [Unreleased] - 2026-01-14

### Added

- Rational: Generic `Rational<T>` struct for any `IBinaryInteger<T>` type

## [0.1.1] - 2026-01-14

### Added

- Abstractions: Pure interfaces for math operations (`IAdditionFunctions<T>`, `IDivisionFunctions<T>`, etc.)
- Algorithms.Generic: Policy-based rational arithmetic algorithms via `RationalOperations` class
- Models: Checked and unchecked arithmetic policy implementations
- Algorithms.Specialized: Convenience wrappers `CheckedRationalOperations`, `UncheckedRationalOperations`, `NumericRationalOperations`
- BigIntegerRational: Non-generic `BigIntegerRational` struct for arbitrary precision

[Unreleased]: https://github.com/qbit86/ratiocinia/compare/v0.1.1-bigintegerrational...HEAD

[0.1.1]: https://github.com/qbit86/ratiocinia/releases/tag/v0.1.1-bigintegerrational
