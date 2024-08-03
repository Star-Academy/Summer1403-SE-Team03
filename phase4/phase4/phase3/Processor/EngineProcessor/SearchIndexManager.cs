using phase3.InvertedIndexManager;
using phase3.Models;
using phase3.Processor.FileProcessorFactory;
using phase3.Processor.QueryProcessor;

namespace phase3.Processor;

public class SearchIndexManager : ISearchIndexManager
{
    private readonly IFileProcessor _fileProcessor;
    private readonly IInvertedIndexBuilder _invertedIndexBuilder;
    public Dictionary<string, List<string>> InvertedIndexDictionary { get; private set; }

    public SearchIndexManager(IFileProcessor fileProcessor, IInvertedIndexBuilder invertedIndexBuilder)
    {
        _fileProcessor = fileProcessor ?? throw new ArgumentNullException(nameof(fileProcessor));
        _invertedIndexBuilder = invertedIndexBuilder ?? throw new ArgumentNullException(nameof(invertedIndexBuilder));
    }

    public Dictionary<string, List<string>> GetInvertedIndex(List<DataFile> dataFiles)
    {
        var data = _fileProcessor.ProcessDocumentsForIndexing(dataFiles, new ProcessFactory());
        InvertedIndexDictionary = _invertedIndexBuilder.BuildInvertedIndex(data);
        return InvertedIndexDictionary;
    }
}