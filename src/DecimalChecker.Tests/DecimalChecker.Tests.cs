using Xunit;
using DChecker = GrimPop.DecimalChecker.DecimalChecker;

namespace GrimPop.DecimalChecker.Tests;
public class DecimalCheckerTests
{
    [Fact]
    public void Construction()
    {
        var checker = new DChecker(2, 1);
        Assert.NotNull(checker);
        Assert.Equal(2, checker.Scale);
        Assert.Equal(1, checker.Precision);
    }

    [Fact]
    public void Construction_Parameterised()
    {
        var checker = new DChecker(precision: 1, scale: 2);
        Assert.NotNull(checker);
        Assert.Equal(2, checker.Scale);
        Assert.Equal(1, checker.Precision);
    }


    [Theory]
    [InlineData(1.2, 2, 1)]
    [InlineData(1.2, 6, 3)]
    public void Decimals_Compatible(decimal input, int precision, int scale){
        var checker = new DChecker(scale, precision);
        Assert.True(checker.IsCompatible(input));
    }

    [Theory]
    [InlineData(1.2, 0, 5)]
    [InlineData(1.2, 5, 0)]
    public void Decimals_InCompatible(decimal input, int precision, int scale){
        var checker = new DChecker(scale, precision);
        Assert.False(checker.IsCompatible(input));
    }

    [Theory]
    [InlineData(1.2, 2, 1)]
    [InlineData(0, 1, 0)]
    [InlineData(99.99, 4, 2)]
    public void IsCompatible_ExactFit_ReturnsTrue(decimal input, int precision, int scale)
    {
        var checker = new DChecker(scale, precision);
        Assert.True(checker.IsCompatible(input));
    }

    [Fact]
    public void IsCompatible_ScaleExceeded_ReturnsFalse()
    {
        var checker = new DChecker(scale: 1, precision: 5);
        Assert.False(checker.IsCompatible(1.23m));
    }

    [Fact]
    public void IsCompatible_PrecisionExceeded_ReturnsFalse()
    {
        var checker = new DChecker(scale: 2, precision: 2);
        Assert.False(checker.IsCompatible(123.45m));
    }
}
