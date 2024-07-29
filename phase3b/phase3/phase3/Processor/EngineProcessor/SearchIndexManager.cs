using phase3.FileManager;
using phase3.InvertedIndexManager;
using phase3.Models;
using phase3.Processor.QueryProcessor;
using phase3.Processor.QueryProcessor.SearchStrategy;

namespace phase3.Processor;

public class SearchIndexManager : ISearchIndexManager
{
    private readonly IFileProcessor _fileProcessor;
    private readonly IInvertedIndexBuilder _invertedIndexBuilder;
    public Dictionary<string, List<string>> InvertedIndexDictionary { get; private set; }

    public SearchIndexManager(IFileProcessor fileProcessor, IInvertedIndexBuilder invertedIndexBuilder)
    {
        if (fileProcessor is null || invertedIndexBuilder is null)
        {
            throw new ArgumentNullException();
        }
        else
        {
            _fileProcessor = fileProcessor;
            _invertedIndexBuilder = invertedIndexBuilder;
        }
    }

    public Dictionary<string, List<string>> GetInvertedIndex(List<DataFile> dataFiles)
    {
        var data = _fileProcessor.ProcessDocumentsForIndexing(dataFiles);
        InvertedIndexDictionary = _invertedIndexBuilder.BuildInvertedIndex(data);
        return InvertedIndexDictionary;
    }
}