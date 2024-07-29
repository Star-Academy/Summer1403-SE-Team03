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
        if (_searchIndexManager.GetInvertedIndex(_textFileReader.ReadFile(Resources.dataPath))
            .TryGetValue(input, out List<string> documents))
            return documents;
        return new List<string>();
    }
}