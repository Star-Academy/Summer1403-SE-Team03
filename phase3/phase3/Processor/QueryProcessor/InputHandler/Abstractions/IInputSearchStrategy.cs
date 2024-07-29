namespace phase3.Processor.QueryProcessor.SearchStrategy.IFilterStrategy;

public interface IInputSearchStrategy
{
    List<string> Apply(IReadOnlyList<string> inputWords);
}