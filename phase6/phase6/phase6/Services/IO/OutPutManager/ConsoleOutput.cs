using phase6.Services.Processor.QueryProcessor.SearchStrategy.Abstractions;

namespace phase6.Services.IO.OutPutManager;

public class ConsoleOutput : IOutput<List<string>>
{
    private readonly ISearchStrategy _searchStrategy;

    public ConsoleOutput(ISearchStrategy searchStrategy)
    {
        _searchStrategy = searchStrategy;
    }

    public List<string> OutputProcess(string input)
    {
        var results = _searchStrategy.ManageSearchStrategy(input);
        return results.ToList();
    }
}