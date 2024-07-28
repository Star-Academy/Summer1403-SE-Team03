namespace phase3.Processor.QueryProcessor.SearchStrategy.IFilterStrategy;

public interface IFilterSearchStrategy
{
    List<string> Apply(IReadOnlyList<string> inputWords);
}