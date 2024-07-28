using phase3.FileManager;

namespace phase3.Processor.QueryProcessor;

public class SearchOperation
{
    public static List<string> SearchText(string input)
    {
        var fileReader = new FileReader();
        var engineProcessor = new EngineProcessor();
        engineProcessor.SetInvertedIndexDocx(fileReader.ReadFile(Resources.dataPath));
        return engineProcessor.InvertedIndexDictionary.TryGetValue(input, out List<string> documents) ? documents : new List<string>();
    }
}