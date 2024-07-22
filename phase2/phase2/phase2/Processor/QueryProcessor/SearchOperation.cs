namespace phase2.Processor.QueryProcessor;

public class SearchOperation
{
    public static List<string> SearchText(string input , Dictionary<string, List<string>> docx)
    {
        if (docx.TryGetValue(input, out List<string> documents))
        {
            return documents;
        }
        else
        {
            throw new KeyNotFoundException($"Your input does not exist in any doc");
        }
    }
}