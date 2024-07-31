using phase3.Processor.QueryProcessor.SearchStrategy.SearchStrategyImplemention;

namespace phase3Test.Processor.QueryProcessor.InputHandler.SearchStrategyImplemenation;

public class AtLeastOneInputStrategyTest
{
    [Fact]
    public void AtLeastOneInputStrategy_ShouldSplitPluses_WhenInputContainPlusSign()
    {
        // arrange
        List<string> testData = new List<string> { "+salam", "+mahdi", "-sara", "*das", "ali" };

        List<String> expectedTestData = new List<string> { "salam", "mahdi" };

        AtLeastOneInputStrategy atLeastOneInputStrategy = new AtLeastOneInputStrategy();
        // act
        var result = atLeastOneInputStrategy.Apply(testData);
        // assert
        Assert.True(expectedTestData.Count == result.Count);
    }

    [Fact]
    public void AtLeastOneInputStrategy_ShouldNotContainAnyWord_WhenInputNotContainAnyWord()
    {
        // arrange
        List<String> testData = new List<string>() { };
        List<String> expectedTestData = new List<string>();
        AtLeastOneInputStrategy atLeastOneInputStrategy = new AtLeastOneInputStrategy();
        // act
        List<String> result = atLeastOneInputStrategy.Apply(testData);
        // assert
        Assert.Equal(expectedTestData, result);
    }
}