namespace phase3.Processor.QueryProcessor.SearchStrategy;

public class SearchResultsFilter
{
    public IEnumerable<string> GetResult(List<string> atLeastOneResult, List<string> wordsShouldBeResult,
        List<string> wordsShouldNotBeResult)
    {
        if (atLeastOneResult.Count == 0)
            return wordsShouldBeResult.Except(wordsShouldNotBeResult).ToList();
        if (wordsShouldBeResult.Count == 0)
            return atLeastOneResult.Except(wordsShouldNotBeResult).ToList();
        return atLeastOneResult.Intersect(wordsShouldBeResult).Except(wordsShouldNotBeResult).ToList();
    }
}