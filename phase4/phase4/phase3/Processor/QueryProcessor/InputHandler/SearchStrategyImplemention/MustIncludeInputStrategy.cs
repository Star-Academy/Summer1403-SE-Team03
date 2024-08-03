using phase3.Models;
using phase3.Processor.QueryProcessor.SearchStrategy.IFilterStrategy;

namespace phase3.Processor.QueryProcessor.SearchStrategy.SearchStrategyImplemention;

public class MustIncludeInputStrategy : IInputSearchStrategy
{
    public List<string> Apply(IReadOnlyList<string> inputWords)
    {
        List<string> wordSouldBe = new List<string>();
        foreach (string word in inputWords)
        {
            if (!word.StartsWith(QueryConstants.AtLeastOneSign) && !word.StartsWith(QueryConstants.MustNotContainSign))
                wordSouldBe.Add(word);
        }

        return wordSouldBe;
    }
}