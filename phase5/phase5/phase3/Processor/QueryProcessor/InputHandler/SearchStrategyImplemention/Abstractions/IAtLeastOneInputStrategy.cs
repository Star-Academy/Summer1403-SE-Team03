namespace phase3.Processor.QueryProcessor.SearchStrategy.IFilterStrategy;

public interface IAtLeastOneInputStrategy
{
    List<string> Apply(IReadOnlyList<string> inputWords);
}