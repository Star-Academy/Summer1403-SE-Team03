using phase3.FileManager;
using phase3.InvertedIndexManager;
using phase3.Processor.QueryProcessor.SearchStrategy;

namespace phase3.Processor.QueryProcessor;

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
        return documents ?? [];
    }
}