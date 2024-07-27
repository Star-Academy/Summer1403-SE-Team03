using phase3.FileManager;
using phase3.InvertedIndexManager;
using phase3.Models;
using phase3.Processor.QueryProcessor;

namespace phase3.Processor;

public class EngineProcessor : IEngineProcessor
{
    public Dictionary<string, List<string>> InvertedIndexDictionary { get; set; }
    public void SetInvertedIndexDocx(List<DataFile> dataFiles)
    {
        var data = FileProcessor.ProcessDocumentsForIndexing(dataFiles);
        InvertedIndexDictionary = InvertedIndexBuilder.BuildInvertedIndex(data);
    }
}