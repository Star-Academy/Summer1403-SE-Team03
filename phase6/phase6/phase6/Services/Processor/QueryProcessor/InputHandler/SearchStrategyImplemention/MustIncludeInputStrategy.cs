using phase6.Models.Models;
using phase6.Services.Processor.QueryProcessor.InputHandler.SearchStrategyImplemention.Abstractions;

namespace phase6.Services.Processor.QueryProcessor.InputHandler.SearchStrategyImplemention;

public class MustIncludeInputStrategy : IMustIncludeInputStrategy
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