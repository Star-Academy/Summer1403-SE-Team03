using phase3.FileManager;
using phase3.InvertedIndexManager;

namespace phase3.Processor;

public class EngineProcessor
{
    private static readonly EngineProcessor _engineProcessor = new();

    public Dictionary<string, List<string>> InvertedIndexDictionary { get; set; }

    private EngineProcessor()
    {
        SetInvertedIndexDocx();
    }

    public static EngineProcessor Instance => _engineProcessor;

    private void SetInvertedIndexDocx()
    {
        var data = FileProcessor.ProcessDocumentsForIndexing(FileReader.Instance.ReadFiles());
        InvertedIndexDictionary = InvertedIndexBuilder.BuildInvertedIndex(data);
    }
}