using phase3.Processor.QueryProcessor.SearchStrategy.SearchStrategyImplemention;

namespace phase3Test.Processor.QueryProcessor.InputHandler.SearchStrategyImplemenation;

public class MustIncludeInputStrategyTest
{
    private readonly MustIncludeInputStrategy _sut = new MustIncludeInputStrategy();

    [Fact]
    public void MustIncludeInputStrategy_ShouldSplitOrdinaryWord_WhenInputContainNoSign()
    {
        // arrange
        List<string> testData = new() { "+salam", "+mahdi", "-sara", "ali" };
        List<string> expectedTestData = new() { "ali" };
        
        // act
        var result = _sut.Apply(testData);
        
        // assert
        Assert.True(expectedTestData.Count == result.Count);
    }

    [Fact]
    public void MustIncludeInputStrategy_ShouldNotContainAnyWord_WhenInputNotContainAnyWord()
    {
        // arrange
        List<string> testData = new() { };
        List<string> expectedTestData = new();
        
        // act
        var result = _sut.Apply(testData);
        
        // assert
        Assert.Equal(expectedTestData, result);
    }
}