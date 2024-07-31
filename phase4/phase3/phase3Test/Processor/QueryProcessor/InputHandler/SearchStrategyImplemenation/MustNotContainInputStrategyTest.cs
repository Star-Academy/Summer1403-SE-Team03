using phase3.Processor.QueryProcessor.SearchStrategy.SearchStrategyImplemention;

namespace phase3Test.Processor.QueryProcessor.InputHandler.SearchStrategyImplemenation;

public class MustNotContainInputStrategyTest
{
    [Fact]
    public void MustNotContainInputStrategy_ShouldSplitMinesWord_WhenInputContainMinesSign()
    {
        //arrange
        List<String> testData = new List<string> { "+salam", "+mahdi", "-sara", "ali" };

        List<String> expectedTestData = new List<string> { "sara" };

        MustNotContainInputStrategy mustNotContainInputStrategy = new MustNotContainInputStrategy();
        // act
        var result = mustNotContainInputStrategy.Apply(testData);
        // assert
        Assert.True(expectedTestData.Count == result.Count);
    }

    [Fact]
    public void MustNotContainInputStrategy_ShouldNotContainAnyWord_WhenInputNotContainAnyWord()
    {
        //arrange
        List<String> testData = new List<string>() { };
        List<String> expectedTestData = new List<string>();
        MustNotContainInputStrategy mustNotContainInputStrategy = new MustNotContainInputStrategy();
        // act
        List<String> result = mustNotContainInputStrategy.Apply(testData);
        // assert
        Assert.Equal(expectedTestData, result);
    }
}