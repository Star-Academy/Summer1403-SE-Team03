using phase3.Processor.QueryProcessor.SearchStrategy.SearchStrategyImplemention;

namespace phase3Test.Processor.QueryProcessor.InputHandler.SearchStrategyImplemenation;

public class MustIncludeInputStrategyTest
{
    private readonly MustIncludeInputStrategy _sut = new MustIncludeInputStrategy();

    [Fact]
    public void MustIncludeInputStrategy_ShouldSplitOrdinaryWord_WhenInputContainNoSign()
    {
        // Arrange
        List<string> testData = new() { "+salam", "+mahdi", "-sara", "ali" };
        List<string> expectedTestData = new() { "ali" };

        // Act
        var result = _sut.Apply(testData);

        // Assert
        Assert.True(expectedTestData.Count == result.Count);
    }

    [Fact]
    public void MustIncludeInputStrategy_ShouldNotContainAnyWord_WhenInputNotContainAnyWord()
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