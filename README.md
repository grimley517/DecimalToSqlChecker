# DecimalToSqlChecker
A small library to help one check that ones decimal values will fit into a sql field with a given precision and scale

[![.github/workflows/dotnet.yml](https://github.com/grimley517/DecimalToSqlChecker/actions/workflows/dotnet.yml/badge.svg)](https://github.com/grimley517/DecimalToSqlChecker/actions/workflows/dotnet.yml)

## Problem

C# decimal values don't always fit into sql fields.  Although an error is raised when one tries to store a value, sometimes you just need to know before that its going to be a problem.

## Solution

This Library checks the scale and precision of a decimal value.

Simple useage

```csharp
    [Theory]
    [InlineData(0.2,  0.2)]
    [InlineData(9.99,  9.99)]
    [InlineData(9.999, 10.00)]
    [InlineData(2.222, 2.22)]
    [InlineData(9.9999,  10.00)]
    [InlineData(9.99999999,  10.00)]
    [InlineData(99.99,  99.99)]
    [InlineData(999.9,  999.9)]
    [InlineData(9999,  9999)]
    [InlineData(9998.00,  9998)]
    public void CheckValidator_Precision4_Scale2_NumericOutput(decimal input, decimal output)
    {
        var validator = new DecimalValidator(targetPrecision: 4, targetScale: 2);
        var output = validator.Validate(input);

        Assert.Equal(expectedOutput, actualOutput);
    }
```

Note that the output will fit into the expected field. It may be rounded, the rounding strategy can be set in the validator.

See the tests for further examples.

## Architecture

### C4 Context View

```mermaid
C4Context
    title System Context Diagram for DecimalToSqlChecker

    Person(developer, "Developer", "A .NET developer who needs to validate decimal values before storing them in a SQL database.")

    System(decimalToSqlChecker, "DecimalToSqlChecker", "A .NET library that checks whether a decimal value fits within a SQL field's defined precision and scale.")

    System_Ext(sqlDatabase, "SQL Database", "A relational database (e.g. SQL Server) that stores decimal values with defined precision and scale.")

    Rel(developer, decimalToSqlChecker, "Uses to validate decimals")
    Rel(decimalToSqlChecker, sqlDatabase, "Validates values against field constraints of")
```

### C4 Container View

```mermaid
C4Container
    title Container Diagram for DecimalToSqlChecker

    Person(developer, "Developer", "A .NET developer consuming the library.")

    Container_Boundary(library, "DecimalToSqlChecker Library") {
        Container(decimalValidator, "DecimalValidator", ".NET Class", "Validates that a decimal value fits within a target SQL field precision and scale. Supports configurable rounding strategies.")
        Container(decimalChecker, "DecimalChecker", ".NET Class", "Checks the precision and scale of a decimal value against SQL field constraints.")
        Container(decimalExtensions, "DecimalExtensions", ".NET Extension Methods", "Provides extension methods for working with decimal precision and scale.")
    }

    System_Ext(sqlDatabase, "SQL Database", "A relational database that stores decimal values with defined precision and scale.")

    Rel(developer, decimalValidator, "Creates and calls Validate()")
    Rel(decimalValidator, decimalChecker, "Uses")
    Rel(decimalValidator, decimalExtensions, "Uses")
    Rel(decimalValidator, sqlDatabase, "Validates values against constraints of")
```
