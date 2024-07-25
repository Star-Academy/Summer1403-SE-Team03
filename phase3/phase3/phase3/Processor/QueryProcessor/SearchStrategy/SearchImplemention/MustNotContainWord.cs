namespace phase3.Processor.QueryProcessor.SearchStrategy;

public class MustNotContainWord
{
    public List<string> Execute (List<string> wordsShouldNotBe)
    {
        HashSet<string> result = new();
        foreach (var element in wordsShouldNotBe)
        {
            List<string> tmp = SearchOperation.SearchText(element);
            foreach (var element2 in tmp) result.Add(element2);
        }

        return result.ToList();
    }
}