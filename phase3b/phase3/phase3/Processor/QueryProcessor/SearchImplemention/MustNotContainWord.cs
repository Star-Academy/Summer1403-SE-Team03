namespace phase3.Processor.QueryProcessor.SearchStrategy;

public class MustNotContainWord : ISearchStrategy
{
    private readonly ISearchOperation _searchOperation;
    public string sign { get; set; }

    public MustNotContainWord(ISearchOperation searchOperation)
    {
        sign = "-";
        _searchOperation = searchOperation;
    }

    public List<string> ProcessOnWords(IReadOnlyList<string> wordsShouldNotBe)
    {
        var finalResult = wordsShouldNotBe
            .SelectMany(word => _searchOperation.SearchText(word))
            .ToHashSet()
            .ToList();
        return finalResult;
    }
}