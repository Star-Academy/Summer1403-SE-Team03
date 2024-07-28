using phase3.Processor.QueryProcessor.SearchStrategy.IFilterStrategy;

namespace phase3.Processor.QueryProcessor.SearchStrategy.SearchStrategyImplemention;

public class MustNotContainInputStrategy : IInputSearchStrategy
{
    public List<string> Apply(IReadOnlyList<string> inputWords)
    {
        List<string> wordShouldNotBe = new List<string>();
        foreach (string word in inputWords)
        {
            if (word.StartsWith('-'))
            {
                wordShouldNotBe.Add(word.TrimStart('-'));
            }
        }

        return wordShouldNotBe;
    }
}