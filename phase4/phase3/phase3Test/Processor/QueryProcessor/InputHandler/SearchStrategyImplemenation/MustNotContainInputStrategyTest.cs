using phase3.Processor.QueryProcessor.SearchStrategy.SearchStrategyImplemention;

namespace phase3Test.Processor.QueryProcessor.InputHandler.SearchStrategyImplemenation;

public class MustNotContainInputStrategyTest
{
    private readonly MustNotContainInputStrategy _sut = new MustNotContainInputStrategy();

    [Fact]
    public void MustNotContainInputStrategy_ShouldSplitMinesWord_WhenInputContainMinesSign()
    {
        //arrange
        List<string> testData = new() { "+salam", "+mahdi", "-sara", "ali" };

        List<string> expectedTestData = new() { "sara" };

        // act
        var result = _sut.Apply(testData);
        // assert
        Assert.True(expectedTestData.Count == result.Count);
    }

    [Fact]
    public void MustNotContainInputStrategy_ShouldNotContainAnyWord_WhenInputNotContainAnyWord()
    {
        //arrange
        List<string> testData = new() { };
        List<string> expectedTestData = new();
        // act
        var result = _sut.Apply(testData);
        // assert
        Assert.Equal(expectedTestData, result);
    }
}