using phase3.Exceotions;
using phase3.Processor.QueryProcessor.SearchStrategy.IFilterStrategy;
using phase3.Processor.QueryProcessor.SearchStrategy.SearchStrategyImplemention;

namespace phase3.Processor.QueryProcessor.SearchStrategy;

public class SearchQueryParser
{
    public void ManageInputSearchStrategy(IReadOnlyList<string> splitInput, out List<string> atLeastOne,
        out List<string> wordsShouldBe, out List<string> wordsShouldNotBe)
    {
        atLeastOne = new List<string>(new AtLeastOneInputStrategy().Apply(splitInput));
        wordsShouldBe = new List<string>(new MustIncludeInputStrategy().Apply(splitInput));
        wordsShouldNotBe = new List<string>(new MustNotContainInputStrategy().Apply(splitInput));
    }
}