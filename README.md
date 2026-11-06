# DecimalToSqlChecker
A small library to help one check that ones decimal values will fit into a sql field with a given precision and scale

[![.github/workflows/dotnet.yml](https://github.com/grimley517/DecimalToSqlChecker/actions/workflows/dotnet.yml/badge.svg)](https://github.com/grimley517/DecimalToSqlChecker/actions/workflows/dotnet.yml)

## Problem

C# decimal values don't always fit into sql fields.  Although an error is raised when one tries to store a value, sometimes you just need to know before that its going to be a problem.

## Solution

This Library checks the scale and precision of a decimal value.

Simple useage

```csharp
using GrimPop.DecimalChecker;

// A SQL decimal(4, 2) field: up to 4 digits in total, 2 after the decimal point.
var validator = new DecimalValidator(targetPrecision: 4, targetScale: 2);

validator.Validate(2.222m);    // 2.22  (rounded to fit the scale)
validator.Validate(9.999m);    // 10.00 (rounded, still fits the precision)
validator.Validate(99.99m);    // 99.99 (already fits)
validator.Validate(12345m);    // null  (cannot fit, even after rounding)
```

`Validate` returns a value that fits the target field, rounding if needed. If the value cannot fit, it returns `null`, or throws a `DecimalValidationException` when `throwErrorOnValidationFail: true` is passed to the constructor. The rounding strategy defaults to `MidpointRounding.AwayFromZero` and can be set in the validator.

See the tests for further examples.

## Architecture

### C4 Context View

```mermaid
C4Context
    title System Context Diagram for DecimalToSqlChecker

    Person(developer, "Developer", "A .NET developer who needs to validate decimal values before storing them in a SQL database.")

    System(decimalToSqlChecker, "DecimalToSqlChecker", "A .NET library that checks whether a decimal value fits within a SQL field's defined precision and scale.")

    System_Ext(sqlDatabase, "SQL Database", "A relational database (e.g. SQL Server) that stores decimal values with defined precision and scale.")

    Rel(developer, decimalToSqlChecker, "Uses to validate decimals before storing")
```

### C4 Component View

```mermaid
C4Component
    title Component Diagram for DecimalToSqlChecker

    Person(developer, "Developer", "A .NET developer consuming the library.")

    Container_Boundary(library, "DecimalToSqlChecker Library") {
        Component(decimalValidator, "DecimalValidator", ".NET Class", "Validates that a decimal value fits within a target SQL field precision and scale. Supports configurable rounding strategies.")
        Component(decimalChecker, "DecimalChecker", ".NET Class", "Checks the precision and scale of a decimal value against SQL field constraints.")
        Component(decimalExtensions, "DecimalExtensions", ".NET Extension Methods", "Provides extension methods for working with decimal precision and scale.")
    }

    Rel(developer, decimalValidator, "Creates and calls Validate()")
    Rel(decimalValidator, decimalChecker, "Uses")
    Rel(decimalValidator, decimalExtensions, "Uses")
```
