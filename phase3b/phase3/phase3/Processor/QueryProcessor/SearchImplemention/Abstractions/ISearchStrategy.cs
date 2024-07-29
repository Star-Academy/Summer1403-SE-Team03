namespace phase3.Processor.QueryProcessor.SearchStrategy;

public interface ISearchStrategy
{
    List<string> ProcessOnWords(IReadOnlyList<string> input);
}