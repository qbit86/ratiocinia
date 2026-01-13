# Changelog

## Unreleased - 2026-01-14

### Added

- Algorithms.Generic: Policy-based rational arithmetic algorithms via `RationalOperations` class
- Models: Checked and unchecked arithmetic policy implementations
- Algorithms.Specialized: Convenience wrappers `CheckedRationalOperations`, `UncheckedRationalOperations`, `NumericRationalOperations`
- Rational: Generic `Rational<T>` struct for any `IBinaryInteger<T>` type
- BigIntegerRational: Non-generic `BigIntegerRational` struct for arbitrary precision

[0.1.0] - 2026-01-14

- Abstractions: Pure interfaces for math operations (`IAdditionFunctions<T>`, `IDivisionFunctions<T>`, etc.)

[0.1.0]: https://github.com/qbit86/ratiocinia/releases/tag/v0.1.0-abstractions
