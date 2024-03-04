namespace GrimPop.DecimalChecker;

/// <summary>
/// A decimal did not pass validation, 
/// </summary>
[Serializable]
public class DecimalValidationException : Exception{
    /// <summary>
    /// The input that failed validation
    /// </summary>
    public decimal FailedInput { get; init; }

    public DecimalValidationException()
    {
    }
    public DecimalValidationException(string? message): base(message)
    {
    }
    public DecimalValidationException(string? message, Exception innerException): base( message, innerException)
    {
    }
    public DecimalValidationException(decimal input):base()
    {
        FailedInput = input;
    }
}