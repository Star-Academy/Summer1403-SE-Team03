using phase6.Models.Models;
using phase6.Services.Processor.QueryProcessor.InputHandler.SearchStrategyImplemention.Abstractions;

namespace phase6.Services.Processor.QueryProcessor.InputHandler.SearchStrategyImplemention;

public class MustNotContainInputStrategy : IMustNotContainInputStrategy
{
    public List<string> Apply(IReadOnlyList<string> inputWords)
    {
        List<string> wordShouldNotBe = new List<string>();
        foreach (string word in inputWords)
        {
            if (word.StartsWith(QueryConstants.MustNotContainSign))
            {
                wordShouldNotBe.Add(word.TrimStart(char.Parse(QueryConstants.MustNotContainSign)));
            }
        }

        return wordShouldNotBe;
    }
}