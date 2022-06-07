using GrimPop.DecimalChecker;
using Xunit;

namespace GrimPop.DecimalChecker.Tests;

public class ValidatorTests
{
    [Theory]
    [InlineData(0.2, true, 0.2)]
    [InlineData(9.99, true, 9.99)]
    [InlineData(9.999, true, 9.999)]
    [InlineData(9.9999, true, 9.9999)]
    [InlineData(9.99999999, true, 9.99999999)]
    [InlineData(99.99, true, 99.99)]
    [InlineData(999.99, false, 999.99)]
    [InlineData(999.9, true, 999.9)]
    [InlineData(9999, true, 9999)]
    [InlineData(9998.00, true, 9998)]
    public void CheckValidator_Precision4_Scale2_BooleanOutput(decimal input, bool success, decimal expectedOutput)
    {
        var actualInput = input;
        var validator = new DecimalValidator(targetPrecision: 4, targetScale: 2);
        var actualsuccess = validator.Validate(actualInput);

        Assert.Equal(success, actualsuccess);
        Assert.Equal(expectedOutput, input);
    }
}