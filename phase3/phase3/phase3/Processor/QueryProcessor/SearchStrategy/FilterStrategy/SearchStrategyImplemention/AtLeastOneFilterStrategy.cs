using phase3.Processor.QueryProcessor.SearchStrategy.IFilterStrategy;

namespace phase3.Processor.QueryProcessor.SearchStrategy.SearchStrategyImplemention;

public class AtLeastOneFilterStrategy : IFilterSearchStrategy
{
    public void Apply(string element, List<string> atLeastOne, List<string> wordsShouldBe, List<string> wordsShouldNotBe)
    {
        atLeastOne.Add(element.Substring(1));
    }
}