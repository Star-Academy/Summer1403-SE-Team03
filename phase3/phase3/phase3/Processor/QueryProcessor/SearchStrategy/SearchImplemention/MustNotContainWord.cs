
namespace phase3.Processor.QueryProcessor.SearchStrategy;
public class MustNotContainWord : ISearchStrategy
{
    public List<string> ProcessOnWords(List<string> wordsShouldNotBe)
    {
        var finalResult = wordsShouldNotBe
            .SelectMany(word => SearchOperation.SearchText(word))
            .ToHashSet()
            .ToList();
        return finalResult.ToList();
    }
}