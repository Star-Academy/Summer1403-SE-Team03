using phase3.FileManager;
using phase3.InvertedIndexManager;
using phase3.Models;
using phase3.Processor.QueryProcessor;

namespace phase3.Processor;

public class EngineProcessor : IEngineProcessor
{
    private readonly IFileProcessor _fileProcessor;
    private readonly InvertedIndexBuilder _invertedIndexBuilder ;


    public EngineProcessor(IFileProcessor fileProcessor , InvertedIndexBuilder invertedIndexBuilder)
    {
        _fileProcessor = fileProcessor;
        _invertedIndexBuilder = invertedIndexBuilder;
    }

    public Dictionary<string, List<string>> InvertedIndexDictionary { get; set; }
    
    public void SetInvertedIndexDocx(List<DataFile> dataFiles)
    {
        var data = _fileProcessor.ProcessDocumentsForIndexing(dataFiles);
        InvertedIndexDictionary = _invertedIndexBuilder.BuildInvertedIndex(data);
    }
}