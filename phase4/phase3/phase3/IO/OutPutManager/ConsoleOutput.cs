using phase3.Processor.QueryProcessor.SearchStrategy;

namespace phase3.IO.OutPutManager;

public class ConsoleOutput : IOutput<List<string>>
{
    private readonly SearchStrategy _searchStrategy;

    public ConsoleOutput(SearchStrategy searchStrategy)
    {
        _searchStrategy = searchStrategy;
    }

    public List<string> OutputProcess(string input)
    {
        var results = _searchStrategy.ManageSearchStrategy(input);
        return results.ToList();
    }
}