
using phase3.Processor.QueryProcessor.SearchStrategy.IFilterStrategy;
using phase3.Processor.QueryProcessor.SearchStrategy.SearchStrategyImplemention;
namespace phase3.Processor.QueryProcessor.SearchStrategy;

public class SearchQueryParser
{
    public void ManageInputSearchStrategy(List<string> splitInput, out List<string> atLeastOne,
        out List<string> wordsShouldBe, out List<string> wordsShouldNotBe)
    {
        atLeastOne = new List<string>();
        wordsShouldBe = new List<string>();
        wordsShouldNotBe = new List<string>();
        
        var strategies = new Dictionary<char, IFilterSearchStrategy>
        {
            { '+', new AtLeastOneFilterStrategy() },
            { '-', new MustNotContainFilterStrategy() }
        };

        var defaultStrategy = new MustIncludeFilterStrategy();

        foreach (var element in splitInput)
        {
            var firstChar = element.ElementAt(0);
            if (strategies.TryGetValue(firstChar, out var strategy))
            {
                strategy.Apply(element, atLeastOne, wordsShouldBe, wordsShouldNotBe);
            }
            else
            {
                defaultStrategy.Apply(element, atLeastOne, wordsShouldBe, wordsShouldNotBe);
            }
        }
    }
}