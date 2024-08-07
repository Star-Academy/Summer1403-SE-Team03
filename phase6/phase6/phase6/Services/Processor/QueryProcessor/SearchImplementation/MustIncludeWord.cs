using phase6.Services.Processor.QueryProcessor.SearchImplemention.Abstractions;
using phase6.Services.Processor.QueryProcessor.SearchStrategy.Abstractions;

namespace phase6.Services.Processor.QueryProcessor.SearchImplemention;

public class MustIncludeWord : IInputManagement
{
    private readonly ISearchOperation _searchOperation;

    public MustIncludeWord(ISearchOperation searchOperation)
    {
        _searchOperation = searchOperation;
    }

    public List<string> ProcessOnWords(IReadOnlyList<string> wordsShouldBe)
    {
        if (!wordsShouldBe.Any())
        {
            return new List<string>();
        }

        var finalResult = wordsShouldBe
            .Select(word => _searchOperation.SearchText(word))
            .Aggregate((result, next) => result
                .Intersect(next).ToList());
        return finalResult;
    }
}