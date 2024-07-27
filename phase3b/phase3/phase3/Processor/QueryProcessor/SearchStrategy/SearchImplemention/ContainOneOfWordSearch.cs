namespace phase3.Processor.QueryProcessor.SearchStrategy;

public class ContainOneOfWordSearch : ISearchStrategy
{
    public List<string> ProcessOnWords(List<string> atLeastOne)
    {
        var finalResult = atLeastOne
            .SelectMany(word => SearchOperation.SearchText(word))
            .ToHashSet()
            .ToList();
        return finalResult.ToList();
    }
}