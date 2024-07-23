using phase2.FileManager;
using phase2.InvertedIndexManager;

namespace phase2.Processor;

public class EngineProcessor
{
    private static EngineProcessor _engineProcessor;

    public EngineProcessor()
    {
        SetInvertedIndexDocx();
    }

    public Dictionary<string, List<string>> InvertedIndexDictionary { get; set; }

    public static EngineProcessor Instance
    {
        get
        {
            if (_engineProcessor == null) _engineProcessor = new EngineProcessor();
            
            return _engineProcessor;
        }
    }

    private void SetInvertedIndexDocx()
    {
        var data = FileProcessor.ProcessDocumentsForIndexing(FileReader.ReadFiles());
        InvertedIndexDictionary = InvertedIndexBuilder.BuildInvertedIndex(data);
    }
}