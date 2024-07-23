namespace phase2.Processor.QueryProcessor.SearchStrategy;

public class ContainOneOfWordSearch
{
    public static List<String> GetFilesContainingAnyWord(List<String> atLeastOne)
    {
        HashSet<String> result = new HashSet<string>();
        foreach (var element in atLeastOne)
        {
            List<string> tmp = SearchOperation.SearchText(element);
            foreach (var element2 in tmp)
            {
                result.Add(element2);
            }
        }

        return result.ToList();
    }
}