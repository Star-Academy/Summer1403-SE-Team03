namespace phase2.Processor.QueryProcessor.SearchStrategy;

public class MustNotContainWord
{
    public static List<String> GetFilesNotContainingAnyWord(List<String> wordsShouldNotBe)
    {
        HashSet<String> result = new HashSet<string>();
        foreach (var element in wordsShouldNotBe)
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