using phase3.Processor.QueryProcessor.SearchStrategy.SearchStrategyImplemention;

namespace phase3Test.Processor.QueryProcessor.InputHandler.SearchStrategyImplemenation;

public class MustNotContainInputStrategyTest
{
    private readonly MustNotContainInputStrategy _sut = new MustNotContainInputStrategy();

    [Fact]
    public void MustNotContainInputStrategy_ShouldSplitMinesWord_WhenInputContainMinesSign()
    {
        // Arrange
        List<string> testData = new() { "+salam", "+mahdi", "-sara", "ali" };
        List<string> expectedTestData = new() { "sara" };

        // Act
        var result = _sut.Apply(testData);

        // Assert
        Assert.Equal(expectedTestData , result);
    }
    [Fact]
    public void MustNotContainInputStrategy_ShouldSplitMinesWord_WhenInputNotContainMinesSign()
    {
        // Arrange
        List<string> testData = new() { "+salam", "+mahdi", "ali" };
        List<string> expectedTestData = new() {};

        // Act
        var result = _sut.Apply(testData);

        // Assert
        Assert.Equal(expectedTestData , result);
    }

    [Fact]
    public void MustNotContainInputStrategy_ShouldNotContainAnyWord_WhenInputNotContainAnyWord()
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