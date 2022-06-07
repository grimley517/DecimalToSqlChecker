using Xunit;
using DecimalChecker;

namespace DecimalChecker.Tests;
public class DecimalCheckerTests
{
    [Fact]
    public void Construction()
    {
        DecimalChecker checker = new DecimalChecker(2, 1);
        Assert.NotNull(checker);
        Assert.Equal(2, checker.Scale);
        Assert.Equal(1, checker.Precision);
    }

    [Fact]
    public void Construction_Parameterised()
    {
        DecimalChecker checker = new DecimalChecker(precision: 1, scale: 2);
        Assert.NotNull(checker);
        Assert.Equal(2, checker.Scale);
        Assert.Equal(1, checker.Precision);
    }



    [Theory]
    [InlineData(1.2, 2, 1)]
    [InlineData(1.2, 6, 3)]
    public void Decimals_Compatible(decimal input, int precision, int scale){
        DecimalChecker checker = new DecimalChecker(scale, precision);
        Assert.True(checker.IsCompatible(input));
    }

    [Theory]
    [InlineData(1.2, 0, 5)]
    [InlineData(1.2, 5, 0)]
    public void Decimals_InCompatible(decimal input, int precision, int scale){
        DecimalChecker checker = new DecimalChecker(scale, precision);
        Assert.False(checker.IsCompatible(input));
    }
}
