using phase3.FileManager;

namespace phase3.Processor.QueryProcessor;

public class SearchOperation
{
    public static List<string> SearchText(string input)
    {
        FileReader fileReader = new FileReader();
        EngineProcessor engineProcessor = new EngineProcessor();
        engineProcessor.SetInvertedIndexDocx(fileReader.ReadFile(Resources.dataPath));
        if (engineProcessor.InvertedIndexDictionary.TryGetValue(input, out List<string> documents))
            return documents;
        return new List<string>();
    }
}