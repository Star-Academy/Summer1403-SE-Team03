using phase3.FileManager;
using phase3.InvertedIndexManager;
using phase3.Models;
using phase3.Processor.QueryProcessor;
using phase3.Processor.QueryProcessor.SearchStrategy;

namespace phase3.Processor;

public class EngineProcessor : IEngineProcessor
{
    private readonly IFileProcessor _fileProcessor;
    private readonly IInvertedIndexBuilder _invertedIndexBuilder;
    public Dictionary<string, List<string>> InvertedIndexDictionary { get; private set; }

    public EngineProcessor(IFileProcessor fileProcessor, IInvertedIndexBuilder invertedIndexBuilder)
    {
        _fileProcessor = fileProcessor;
        _invertedIndexBuilder = invertedIndexBuilder;
    }

    public Dictionary<string, List<string>> GetInvertedIndex()
    {
        return InvertedIndexDictionary;
    }

    public void SetInvertedIndexDocx(List<DataFile> dataFiles)
    {
        var data = _fileProcessor.ProcessDocumentsForIndexing(dataFiles);
        InvertedIndexDictionary = _invertedIndexBuilder.BuildInvertedIndex(data);
    }
}