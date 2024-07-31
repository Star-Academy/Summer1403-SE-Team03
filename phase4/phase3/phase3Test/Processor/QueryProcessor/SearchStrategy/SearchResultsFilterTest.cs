using phase3.Processor.QueryProcessor.SearchStrategy;

namespace phase3Test.Processor.QueryProcessor.SearchStrategy;

public class SearchResultsFilterTest
{
    [Fact]
    public void GetResult_ShouldReturnExpectedDataFile_WhenInputHaveAllTypeOfResult()
    {
        List<string> atLeastOneResult = new() { "7000", "7001", "7002", "7003" };
        List<string> wordsShouldBeResult = new() { "7000" };
        List<string> wordsShouldNotBeResult = new() { "7003" };
        IEnumerable<string> expectedResult = new List<string>() { "7000" };
        var searchResult = new SearchResultsFilter();
        var result = searchResult.GetResult(atLeastOneResult, wordsShouldBeResult, wordsShouldNotBeResult);
        Assert.Equal(expectedResult, result);
    }

    [Fact]
    public void GetResult_ShouldReturnExpectedDataFile_WhenNotContainWordsShouldBeResult()
    {
        List<string> atLeastOneResult = new() { "7000", "7001", "7003" };
        List<string> wordsShouldBeResult = new() { };
        List<string> wordsShouldNotBeResult = new() { "7003" };
        IEnumerable<string> expectedResult = new List<string>() { "7000", "7001" };
        var searchResult = new SearchResultsFilter();
        var result = searchResult.GetResult(atLeastOneResult, wordsShouldBeResult, wordsShouldNotBeResult);
        Assert.Equal(expectedResult, result);
    }

    [Fact]
    public void GetResult_ShouldReturnExpectedDataFile_WhenNotContainAtLeastOneResult()
    {
        List<string> atLeastOneResult = new() { };
        List<string> wordsShouldBeResult = new() { "7000" };
        List<string> wordsShouldNotBeResult = new() { "7003" };
        IEnumerable<string> expectedResult = new List<string>() { "7000" };
        var searchResult = new SearchResultsFilter();
        var result = searchResult.GetResult(atLeastOneResult, wordsShouldBeResult, wordsShouldNotBeResult);
        Assert.Equal(expectedResult, result);
    }
}