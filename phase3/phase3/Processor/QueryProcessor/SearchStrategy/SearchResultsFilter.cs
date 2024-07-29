namespace phase3.Processor.QueryProcessor.SearchStrategy;

public class SearchResultsFilter
{
    public IEnumerable<string> GetResult(List<string> atLeastOneResult, List<string> wordsShouldBeResult,
        List<string> wordsShouldNotBeResult)
    {
        if (atLeastOneResult.Count == 0)
        {
            return RemoveExcludedElements(wordsShouldBeResult, wordsShouldNotBeResult);
        }

        if (wordsShouldBeResult.Count == 0)
        {
            return RemoveExcludedElements(atLeastOneResult, wordsShouldNotBeResult);
        }

        var intersection = GetIntersection(atLeastOneResult, wordsShouldBeResult);
        return RemoveExcludedElements(intersection, wordsShouldNotBeResult);
    }

    private IEnumerable<string> GetIntersection(IEnumerable<string> firstCollection,
        IEnumerable<string> secondCollection)
    {
        return firstCollection.Intersect(secondCollection).ToList();
    }

    private IEnumerable<string> RemoveExcludedElements(IEnumerable<string> source,
        IEnumerable<string> elementsToExclude)
    {
        return source.Except(elementsToExclude).ToList();
    }
}