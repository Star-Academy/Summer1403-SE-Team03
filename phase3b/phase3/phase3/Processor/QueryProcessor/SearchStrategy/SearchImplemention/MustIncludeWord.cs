namespace phase3.Processor.QueryProcessor.SearchStrategy;

public class MustIncludeWord : ISearchStrategy
{
    public List<string> ProcessOnWords(IReadOnlyList<string> wordsShouldBe)
    {
        var finalResult = wordsShouldBe
            .Select(word => SearchOperation.SearchText(word))
            .Aggregate((result, next) => result.Intersect(next).ToList());
        return finalResult;
    }
}