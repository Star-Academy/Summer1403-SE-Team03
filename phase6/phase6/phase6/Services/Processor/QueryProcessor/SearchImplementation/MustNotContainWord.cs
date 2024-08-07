using phase6.Services.Processor.QueryProcessor.SearchImplemention.Abstractions;
using phase6.Services.Processor.QueryProcessor.SearchStrategy.Abstractions;

namespace phase6.Services.Processor.QueryProcessor.SearchImplemention;

public class MustNotContainWord : IInputManagement
{
    private readonly ISearchOperation _searchOperation;

    public MustNotContainWord(ISearchOperation searchOperation)
    {
        _searchOperation = searchOperation;
    }

    public List<string> ProcessOnWords(IReadOnlyList<string> wordsShouldNotBe)
    {
        if (!wordsShouldNotBe.Any())
        {
            return new List<string>();
        }
        var finalResult = wordsShouldNotBe
            .SelectMany(word => _searchOperation.SearchText(word))
            .ToHashSet()
            .ToList();
        return finalResult;
    }
}