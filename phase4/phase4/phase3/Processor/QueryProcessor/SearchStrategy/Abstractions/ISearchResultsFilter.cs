namespace phase3.Processor.QueryProcessor.SearchStrategy;

public interface ISearchResultsFilter
{
    IEnumerable<string> GetResult(List<string> atLeastOneResult, List<string> wordsShouldBeResult,
        List<string> wordsShouldNotBeResult);
}