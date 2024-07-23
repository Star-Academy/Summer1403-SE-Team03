namespace phase2.Processor.QueryProcessor.SearchStrategy;

public class ContainOneOfWordSearch
{
    public static List<string> GetFilesContainingAnyWord(List<string> atLeastOne)
    {
        HashSet<string> result = new();
        foreach (var element in atLeastOne)
        {
            List<string> searchResult = SearchOperation.SearchText(element);
            foreach (var doc in searchResult) result.Add(doc);
        }

        return result.ToList();
    }
}