using phase6.Models.Models;
using phase6.Services.Processor.EngineProcessor.Abstractions;
using phase6.Services.Processor.InvertedIndexManager.Abstractions;
using phase6.Services.Processor.PreProcessor.Abstractions;
using phase6.Services.Processor.PreProcessor.FileProcessorFactory;

namespace phase6.Services.Processor.EngineProcessor;

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