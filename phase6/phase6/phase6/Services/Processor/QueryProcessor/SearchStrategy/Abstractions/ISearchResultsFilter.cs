namespace phase6.Services.Processor.QueryProcessor.SearchStrategy.Abstractions;

public interface ISearchResultsFilter
{
    IEnumerable<string> GetResult(List<string> atLeastOneResult, List<string> wordsShouldBeResult,
        List<string> wordsShouldNotBeResult);
}