using phase2.FileManager;
using phase2.InvertedIndexManager;
using phase2.Models;

namespace phase2.Processor;



public class EngineProcessor
{
    public static Dictionary<string, List<string>> InvertedIndexDocx { get; set; }

    public static void SetInvertedIndexDocx()
    {
        List<DataFile> data = FileProcessor.ProcessDocumentsForIndexing(FileReader.ReadFiles());
        InvertedIndexDocx =InvertedIndexBuilder.BuildInvertedIndex(data);

    }
}