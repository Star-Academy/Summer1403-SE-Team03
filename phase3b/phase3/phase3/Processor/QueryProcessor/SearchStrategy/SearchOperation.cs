using phase3.FileManager;
using phase3.InvertedIndexManager;
using phase3.Processor.QueryProcessor.SearchStrategy;

namespace phase3.Processor.QueryProcessor;

public class SearchOperation : ISearchOperation
{
    private readonly IFileReader _textFileReader;
    private readonly IEngineProcessor _engineProcessor;
    public SearchOperation(IFileReader textFileReader , IEngineProcessor engineProcessor )
    {
        _textFileReader = textFileReader;
        _engineProcessor = engineProcessor;
    }

    public List<string> SearchText(string input)
    {
        _engineProcessor.SetInvertedIndexDocx(_textFileReader.ReadFile(Resources.dataPath));
        if (_engineProcessor.GetInvertedIndex().TryGetValue(input, out List<string> documents))
            return documents;
        return new List<string>();
    }
}