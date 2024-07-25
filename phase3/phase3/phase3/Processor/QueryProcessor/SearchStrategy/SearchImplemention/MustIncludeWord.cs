namespace phase3.Processor.QueryProcessor.SearchStrategy;

public class MustIncludeWord
{
    public List<string> Execute (List<string> wordsShouldBe)
    {
        List<string> result = new();
        for (var i = 0; i < wordsShouldBe.Count; i++)
        {
            if (i == 0)
                result = SearchOperation.SearchText(wordsShouldBe[i]);
            else
                result = result.Intersect(SearchOperation.SearchText(wordsShouldBe[i])).ToList();
        }

        return result;
    }
}