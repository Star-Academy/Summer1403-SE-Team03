namespace phase3.Processor.QueryProcessor.SearchStrategy;

public class ContainOneOfWordSearch : ISearchStrategy
{
    private readonly ISearchOperation _searchOperation;
    public string sign { get; set; }


    public ContainOneOfWordSearch(ISearchOperation searchOperation)
    {
        sign = "+";
        _searchOperation = searchOperation;
    }

    public List<string> ProcessOnWords(IReadOnlyList<string> atLeastOne)
    {
        var finalResult = atLeastOne
            .SelectMany(word => _searchOperation.SearchText(word))
            .ToHashSet()
            .ToList();
        return finalResult.ToList();
    }
}