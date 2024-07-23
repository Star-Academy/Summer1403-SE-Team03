using System.Collections.Generic;
using phase2.FileManager;
using phase2.InvertedIndexManager;
using phase2.Models;

namespace phase2.Processor;



public class EngineProcessor
{

    public  Dictionary<string, List<string>> InvertedIndexDictionary { get; set; }
    private static EngineProcessor _engineProcessor;
    
    public EngineProcessor()
    {
        SetInvertedIndexDocx();
    }
    public static EngineProcessor Instance
    {
        get
        {
            if (_engineProcessor == null)
            {
                _engineProcessor = new EngineProcessor();
            }
            return _engineProcessor;
        }
    }

    private void SetInvertedIndexDocx()
    {
        List<DataFile> data = FileProcessor.ProcessDocumentsForIndexing(FileReader.ReadFiles());
        InvertedIndexDictionary = InvertedIndexBuilder.BuildInvertedIndex(data);
    }
}