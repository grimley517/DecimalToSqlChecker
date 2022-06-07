namespace GrimPop.DecimalChecker;

public class DecimalValidationException : Exception{
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