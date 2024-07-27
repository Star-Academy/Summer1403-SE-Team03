namespace phase3.Processor.QueryProcessor.SearchStrategy.IFilterStrategy;

public interface IFilterSearchStrategy
{
    void Apply(string element, List<string> atLeastOne, List<string> wordsShouldBe, List<string> wordsShouldNotBe);
}