namespace phase3.Processor.QueryProcessor.SearchStrategy.IFilterStrategy;

public interface IMustIncludeInputStrategy
{
    List<string> Apply(IReadOnlyList<string> inputWords);
}