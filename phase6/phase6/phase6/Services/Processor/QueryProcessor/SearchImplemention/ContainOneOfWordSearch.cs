using phase6.Services.Processor.QueryProcessor.SearchImplemention.Abstractions;
using phase6.Services.Processor.QueryProcessor.SearchStrategy.Abstractions;

namespace phase6.Services.Processor.QueryProcessor.SearchImplemention;

public class ContainOneOfWordSearch : IInputManagement
{
    private readonly ISearchOperation _searchOperation;


    public ContainOneOfWordSearch(ISearchOperation searchOperation)
    {
        _searchOperation = searchOperation;
    }

    public List<string> ProcessOnWords(IReadOnlyList<string> atLeastOne)
    {
        var finalResult = atLeastOne
            .SelectMany(word => _searchOperation.SearchText(word))
            .ToHashSet()
            .ToList();
        return finalResult;
    }
}