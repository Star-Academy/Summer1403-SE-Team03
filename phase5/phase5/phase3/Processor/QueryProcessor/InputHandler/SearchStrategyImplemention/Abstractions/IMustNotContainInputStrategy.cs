namespace phase3.Processor.QueryProcessor.SearchStrategy.IFilterStrategy;

public interface IMustNotContainInputStrategy
{
    List<string> Apply(IReadOnlyList<string> inputWords);
}