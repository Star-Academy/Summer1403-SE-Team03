using phase3.Processor.QueryProcessor.SearchStrategy;

namespace phase3Test.Processor.QueryProcessor.SearchStrategy;

public class SearchResultsFilterTest
{
    private readonly SearchResultsFilter _sut = new SearchResultsFilter();

    [Fact]
    public void
        GetResult_ShouldReturnIntersectOfAtLeastOneResultAndWordsShouldBeResultExpectWordsShouldNotBeResult_WhenInputHaveAllTypeOfResult()
    {
        // Arrange
        var atLeastOneResult = new List<string>() { "7000", "7001", "7002", "7003" };
        var wordsShouldBeResult = new List<string>() { "7000" };
        var wordsShouldNotBeResult = new List<string>() { "7003" };
        var expectedResult = new List<string>() { "7000" };

        // Act
        var result = _sut.GetResult(atLeastOneResult, wordsShouldBeResult, wordsShouldNotBeResult);

        // Assert
        Assert.Equal(expectedResult, result);
    }

    [Fact]
    public void
        GetResult_ShouldReturnIntersectOfAtLeastOneResultAndWordsShouldBeResultExpectWordsShouldNotBeResult_WhenNotContainWordsShouldBeResult()
    {
        // Arrange
        var atLeastOneResult = new List<string>() { "7000", "7001", "7003" };
        var wordsShouldBeResult = new List<string>() { };
        var wordsShouldNotBeResult = new List<string>() { "7003" };
        var expectedResult = new List<string>() { "7000", "7001" };
        var searchResult = new SearchResultsFilter();
        var result = searchResult.GetResult(atLeastOneResult, wordsShouldBeResult, wordsShouldNotBeResult);
        Assert.Equal(expectedResult, result);
    }

    [Fact]
    public void
        GetResult_ShouldReturnIntersectOfAtLeastOneResultAndWordsShouldBeResultExpectWordsShouldNotBeResult_WhenNotContainAtLeastOneResult()
    {
        var atLeastOneResult = new List<string>() { };
        var wordsShouldBeResult = new List<string>() { "7000" };
        var wordsShouldNotBeResult = new List<string>() { "7003" };
        IEnumerable<string> expectedResult = new List<string>() { "7000" };
        var searchResult = new SearchResultsFilter();
        var result = searchResult.GetResult(atLeastOneResult, wordsShouldBeResult, wordsShouldNotBeResult);
        Assert.Equal(expectedResult, result);
    }
}