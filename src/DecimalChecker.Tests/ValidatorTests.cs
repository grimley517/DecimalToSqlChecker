using Xunit;

namespace GrimPop.DecimalChecker.Tests;

public class ValidatorTests
{
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
    public void CheckValidator_Precision4_Scale2_NumericOutput(decimal input, decimal expectedOutput)
    {
        var validator = new DecimalValidator(targetPrecision: 4, targetScale: 2);
        var actualOutput = validator.Validate(input);

        Assert.Equal(expectedOutput, actualOutput);
    }
    [Theory]
    [InlineData(99.99999999)]//Overflows to 100.00
    [InlineData(9999.999)]
    public void CheckValidator_Precision4_Scale2_NullOutput(decimal input)
    {
        var validator = new DecimalValidator(targetPrecision: 4, targetScale: 2);
        var actualOutput = validator.Validate(input);

        Assert.Null(actualOutput);
    }
    [Theory]
    [InlineData(999.99)]
    public void CheckValidator_Precision4_Scale2_Fail_ErrorOutput(decimal input)
    {
        var validator = new DecimalValidator(targetPrecision: 4, targetScale: 2, throwErrorOnValidationFail: true);
        Assert.Throws<DecimalValidationException>(() => validator.Validate(input));
    }

    [Theory]
    [InlineData(99.99)]
    [InlineData(22.22222)]
    public void CheckValidator_Precision4_Scale2_Pass_NoErrorOutput(decimal input)
    {
        var validator = new DecimalValidator(targetPrecision: 4, targetScale: 2, throwErrorOnValidationFail: true);
        validator.Validate(input);
        Assert.True(true);
    }
}
