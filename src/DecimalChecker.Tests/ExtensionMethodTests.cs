using Xunit;

namespace GrimPop.DecimalChecker.Tests;

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
