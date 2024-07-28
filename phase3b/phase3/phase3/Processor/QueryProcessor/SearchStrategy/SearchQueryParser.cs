using phase3.Exceotions;
using phase3.Processor.QueryProcessor.SearchStrategy.IFilterStrategy;
using phase3.Processor.QueryProcessor.SearchStrategy.SearchStrategyImplemention;

namespace phase3.Processor.QueryProcessor.SearchStrategy;

public class SearchQueryParser
{
    public void ManageInputSearchStrategy(IReadOnlyList<string> splitInput, out List<string> atLeastOne,
        out List<string> wordsShouldBe, out List<string> wordsShouldNotBe)
    {
        try
        {
            atLeastOne = new List<string>(new AtLeastOneFilterStrategy().Apply(splitInput));
            wordsShouldBe = new List<string>(new MustIncludeFilterStrategy().Apply(splitInput));
            wordsShouldNotBe = new List<string>(new MustNotContainFilterStrategy().Apply(splitInput));
        }
        catch (InvalidInputException e)
        {
            throw e;
        }
    }
}