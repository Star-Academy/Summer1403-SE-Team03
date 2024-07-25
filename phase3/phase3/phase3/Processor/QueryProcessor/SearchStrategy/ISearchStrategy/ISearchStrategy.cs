namespace phase3.Processor.QueryProcessor.SearchStrategy;

public interface ISearchStrategy
{
    List<string> Execute(List<string> input);
}