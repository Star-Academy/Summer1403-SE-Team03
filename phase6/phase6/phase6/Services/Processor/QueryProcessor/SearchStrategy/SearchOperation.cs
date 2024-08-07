using phase6.Services.IO.InputManager;
using phase6.Services.Processor.EngineProcessor.Abstractions;
using phase6.Services.Processor.QueryProcessor.SearchStrategy.Abstractions;

namespace phase6.Services.Processor.QueryProcessor.SearchStrategy;

public class SearchOperation : ISearchOperation
{
    private readonly IFileReader _textFileReader;
    private readonly ISearchIndexManager _searchIndexManager;

    public SearchOperation(IFileReader textFileReader, ISearchIndexManager searchIndexManager)
    
    {
        _textFileReader = textFileReader;
        _searchIndexManager = searchIndexManager;
    }

    public List<string> SearchText(string input)
    {
        var dataFiles = _textFileReader.ReadFile(Resources.dataPath);
        var documents = _searchIndexManager.GetInvertedIndex(dataFiles)
            .GetValueOrDefault(input);
        return documents ?? new List<string>();
    }
}