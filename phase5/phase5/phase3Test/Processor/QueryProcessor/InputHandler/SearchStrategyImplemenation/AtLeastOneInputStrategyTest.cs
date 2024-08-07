using phase3.Processor.QueryProcessor.SearchStrategy.SearchStrategyImplemention;

namespace phase3Test.Processor.QueryProcessor.InputHandler.SearchStrategyImplemenation;

public class AtLeastOneInputStrategyTest
{
    private readonly AtLeastOneAtLeastOneInputStrategy _sut = new AtLeastOneAtLeastOneInputStrategy();

    [Fact]
    public void AtLeastOneInputStrategy_ShouldSplitPluses_WhenInputContainPlusSign()
    {
        // Arrange
        List<string> testData = new() { "+salam", "+mahdi", "-sara", "*das", "ali" };
        List<string> expectedTestData = new() { "salam", "mahdi" };

        // Act
        var result = _sut.Apply(testData);

        // Assert
        Assert.Equal(expectedTestData , result);
    }
    [Fact]
    public void AtLeastOneInputStrategy_ShouldSplitPluses_WhenInputNotContainPlusSign()
    {
        // Arrange
        List<string> testData = new() { "-sara", "*das", "ali" };
        List<string> expectedTestData = new() {};

        // Act
        var result = _sut.Apply(testData);

        // Assert
        Assert.Equal(expectedTestData , result);
    }

    [Fact]
    public void AtLeastOneInputStrategy_ShouldNotContainAnyWord_WhenInputNotContainAnyWord()
    {
        // Arrange
        List<string> testData = new() { };
        List<string> expectedTestData = new();

        // Act
        var result = _sut.Apply(testData);

        // Assert
        Assert.Equal(expectedTestData, result);
    }
}