using Grimpop.DecimalChecker;
using Xunit;

namespace DecimalChecker.Tests;

public class ExtensionMethodTests
{
    [Theory]
    [InlineData(1.2, 1)]
    [InlineData(0.0, 0)]
    [InlineData(73.267, 3)]
    [InlineData(123.01, 2)]
    public void KnownInputsWith_Scale_PicksScale(decimal input, byte expectedScale){
        var actualScale = input.GetScale();
        Assert.Equal(expectedScale, actualScale);
    }

    [Theory]
    [InlineData(1.2, 2)]
    [InlineData(0.0, 1)]
    [InlineData(73.267, 5)]
    [InlineData(123.01, 5)]
    public void KnownInputsWith_Precision_PicksPrecision(decimal input, byte expectedPrecision){
        var actualPrecision = input.GetPrecision();
        Assert.Equal(expectedPrecision, actualPrecision);
    }
}

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