namespace phase3.Processor.QueryProcessor.SearchStrategy;

public class MustNotContainWord : IInputManagement
{
    private readonly ISearchOperation _searchOperation;

    public MustNotContainWord(ISearchOperation searchOperation)
    {
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