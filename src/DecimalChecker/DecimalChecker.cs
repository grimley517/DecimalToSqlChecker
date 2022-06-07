using System;

namespace GrimPop.DecimalChecker;

/// <inheritdoc />
public class DecimalChecker : IDecimalChecker
{
    /// <inheritdoc />
    public int Scale { get; init; }
    /// <inheritdoc />
    public int Precision { get; init; }

    /// <summary>
    /// Checks the compatibility with a decimal number with the scale and precision set in a SQL seler decimal representation.
    ///
    /// See https://docs.microsoft.com/en-us/sql/t-sql/data-types/precision-scale-and-length-transact-sql?view=sql-server-ver16 for further info
    /// </summary>
    /// <param name="scale">Scale is the number of digits to the right of the decimal point in a decimla number.</param>
    /// <param name="precision">Precision is the number of digits in a decimal number.</param>
    public DecimalChecker(int scale, int precision)
    {
        Scale = scale;
        Precision = precision;
    }

    /// <inheritdoc />
    public bool IsCompatible(decimal input)
    {
        if (GetScale(input) > Scale) return false;
        if (GetPrecision(input) > Precision) return false;
        return true;
    }

    ///<inheritdoc />
    public byte GetScale(decimal input)
    {
        int[] parts = decimal.GetBits(input);
        byte scale = (byte)((parts[3] >> 16) & 0x7F);
        return scale;
    }

    /// <inheritdoc />
    public int GetPrecision(decimal input)
    {
        int[] parts = decimal.GetBits(input);
        parts[3] = 0x0;
        decimal newDecimal = new decimal(parts);
        return newDecimal.ToString().Length;
    }
}
