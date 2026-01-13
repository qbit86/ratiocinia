# Changelog

## Unreleased - 2026-01-14

### Added

- Abstractions: Pure interfaces for math operations (`IAdditionFunctions<T>`, `IDivisionFunctions<T>`, etc.)
- Algorithms.Generic: Policy-based rational arithmetic algorithms via `RationalOperations` class
- Models: Checked and unchecked arithmetic policy implementations
- Algorithms.Specialized: Convenience wrappers `CheckedRationalOperations`, `UncheckedRationalOperations`, `NumericRationalOperations`
- Rational: Generic `Rational<T>` struct for any `IBinaryInteger<T>` type
- BigIntegerRational: Non-generic `BigIntegerRational` struct for arbitrary precision
