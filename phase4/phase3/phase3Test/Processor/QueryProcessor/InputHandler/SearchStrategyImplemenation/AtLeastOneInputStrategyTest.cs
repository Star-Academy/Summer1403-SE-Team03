using phase3.Processor.QueryProcessor.SearchStrategy.SearchStrategyImplemention;

namespace phase3Test.Processor.QueryProcessor.InputHandler.SearchStrategyImplemenation;

public class AtLeastOneInputStrategyTest
{
    private readonly AtLeastOneInputStrategy _sut = new AtLeastOneInputStrategy();

    [Fact]
    public void AtLeastOneInputStrategy_ShouldSplitPluses_WhenInputContainPlusSign()
    {
        // arrange
        List<string> testData = new() { "+salam", "+mahdi", "-sara", "*das", "ali" };
        List<string> expectedTestData = new() { "salam", "mahdi" };
        
        // act
        var result = _sut.Apply(testData);
        
        // assert
        Assert.True(expectedTestData.Count == result.Count);
    }

    [Fact]
    public void AtLeastOneInputStrategy_ShouldNotContainAnyWord_WhenInputNotContainAnyWord()
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