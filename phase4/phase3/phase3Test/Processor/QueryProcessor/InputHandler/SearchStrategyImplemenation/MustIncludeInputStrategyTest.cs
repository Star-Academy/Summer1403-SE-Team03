using phase3.Processor.QueryProcessor.SearchStrategy.SearchStrategyImplemention;

namespace phase3Test.Processor.QueryProcessor.InputHandler.SearchStrategyImplemenation;

public class MustIncludeInputStrategyTest
{
    [Fact]
    public void MustIncludeInputStrategy_ShouldSplitOrdinaryWord_WhenInputContainNoSign()
    {
        // arrange
        List<String> testData = new List<string> { "+salam", "+mahdi", "-sara", "ali" };

        List<String> expectedTestData = new List<string> { "ali" };

        MustIncludeInputStrategy mustIncludeInputStrategy = new MustIncludeInputStrategy();
        // act
        var result = mustIncludeInputStrategy.Apply(testData);
        // assert
        Assert.True(expectedTestData.Count == result.Count);
    }

    [Fact]
    public void MustIncludeInputStrategy_ShouldNotContainAnyWord_WhenInputNotContainAnyWord()
    {
        List<String> testData = new List<string>() { };
        List<String> expectedTestData = new List<string>();
        MustIncludeInputStrategy mustIncludeInputStrategy = new MustIncludeInputStrategy();
        List<String> result = mustIncludeInputStrategy.Apply(testData);
        Assert.Equal(expectedTestData, result);
    }
}