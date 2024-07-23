using phase2.FileManager;
using phase2.InvertedIndexManager;

namespace phase2.Processor;

public class EngineProcessor
{
    private static readonly EngineProcessor _engineProcessor = new EngineProcessor();
    
    public Dictionary<string, List<string>> InvertedIndexDictionary { get; set; }

    private EngineProcessor()
    {
        SetInvertedIndexDocx();
    }

    public static EngineProcessor Instance
    {
        get
        {
            return _engineProcessor;
        }
    }

    private void SetInvertedIndexDocx()
    {
        var data = FileProcessor.ProcessDocumentsForIndexing(FileReader.ReadFiles());
        InvertedIndexDictionary = InvertedIndexBuilder.BuildInvertedIndex(data);
    }
}