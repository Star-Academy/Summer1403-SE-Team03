namespace phase3.Processor.QueryProcessor;

public class SearchOperation
{
    public static List<string> SearchText(string input)
    {
        if (EngineProcessor.Instance.InvertedIndexDictionary.TryGetValue(input, out List<string> documents))
            return documents;
        return new List<string>();
    }
}