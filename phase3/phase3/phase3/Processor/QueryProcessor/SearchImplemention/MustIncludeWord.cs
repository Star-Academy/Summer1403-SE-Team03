namespace phase3.Processor.QueryProcessor.SearchStrategy;

public class MustIncludeWord : ISearchStrategy
{
    private readonly ISearchOperation _searchOperation;

    public MustIncludeWord(ISearchOperation searchOperation)
    {
        _searchOperation = searchOperation;
    }

    public List<string> ProcessOnWords(IReadOnlyList<string> wordsShouldBe)
    {
        var finalResult = wordsShouldBe
            .Select(word => _searchOperation.SearchText(word))
            .Aggregate((result, next) => result
                .Intersect(next).ToList());
        return finalResult;
    }
}