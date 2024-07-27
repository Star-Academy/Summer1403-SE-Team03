using phase3.Processor.QueryProcessor.SearchStrategy.IFilterStrategy;

namespace phase3.Processor.QueryProcessor.SearchStrategy.SearchStrategyImplemention;

public class MustIncludeFilterStrategy : IFilterSearchStrategy
{
    public void Apply(string element, List<string> atLeastOne, List<string> wordsShouldBe, List<string> wordsShouldNotBe)
    {
        wordsShouldBe.Add(element);
    }
}