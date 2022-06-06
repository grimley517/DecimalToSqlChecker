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
}