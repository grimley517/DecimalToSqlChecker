namespace GrimPop.DecimalChecker;

/// <summary>
/// Checks compatability for a decimal in c# to work with a sql server decimal field with a set precision and scale.
/// </summary>
public interface IDecimalChecker
{

    int Scale { get; init; }
    int Precision { get; init; }

    /// <summary>
    /// Gets the precision of a decimal number
    /// </summary>
    /// <param name="input">decimal number to be checked</param>
    /// <returns></returns>
    int GetPrecision(decimal input);

    /// <summary>
    /// Gets the scale of a decimal number
    /// </summary>
    /// <param name="input">decimal number to be checked</param>
    /// <returns></returns>
    byte GetScale(decimal input);

    /// <summary>
    /// Checks compatibility with a sql Server decimal data type
    /// </summary>
    /// <param name="input">decimal number to be checked</param>
    /// <returns></returns>
    bool IsCompatible(decimal input);
}
