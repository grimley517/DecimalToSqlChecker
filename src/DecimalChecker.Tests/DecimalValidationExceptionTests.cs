using Xunit;

namespace GrimPop.DecimalChecker.Tests;

public class DecimalValidationExceptionTests
{
    [Fact]
    public void DefaultConstructor_CreatesException()
    {
        var ex = new DecimalValidationException();
        Assert.NotNull(ex);
    }

    [Fact]
    public void MessageConstructor_SetsMessage()
    {
        var ex = new DecimalValidationException("test message");
        Assert.Equal("test message", ex.Message);
    }

    [Fact]
    public void MessageAndInnerExceptionConstructor_SetsBoth()
    {
        var inner = new InvalidOperationException("inner");
        var ex = new DecimalValidationException("outer", inner);
        Assert.Equal("outer", ex.Message);
        Assert.Same(inner, ex.InnerException);
    }

    [Fact]
    public void InputConstructor_SetsFailedInput()
    {
        var ex = new DecimalValidationException(123.456m);
        Assert.Equal(123.456m, ex.FailedInput);
    }
}
