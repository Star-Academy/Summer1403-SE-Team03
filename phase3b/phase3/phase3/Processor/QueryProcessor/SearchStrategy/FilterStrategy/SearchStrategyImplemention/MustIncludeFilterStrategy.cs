using phase3.Processor.QueryProcessor.SearchStrategy.IFilterStrategy;

namespace phase3.Processor.QueryProcessor.SearchStrategy.SearchStrategyImplemention;

public class MustIncludeFilterStrategy : IFilterSearchStrategy
{
    public List<string> Apply(IReadOnlyList<string> inputWords)
    {
        List<string> wordSouldBe = new List<string>();
        foreach (string word in inputWords)
        {
            if (!word.StartsWith('+') || !word.StartsWith('-'))
            wordSouldBe.Add(word);
        }

        return wordSouldBe;
    }
}