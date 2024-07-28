using phase3.Processor.QueryProcessor.SearchStrategy.IFilterStrategy;

namespace phase3.Processor.QueryProcessor.SearchStrategy.SearchStrategyImplemention;

public class AtLeastOneInputStrategy : IInputSearchStrategy
{
    public List<string> Apply(IReadOnlyList<string> inputWords)
    {
        List<string> atLeastOne = new List<string>();
        foreach (string word in inputWords)
        {
            if (word.StartsWith('+'))
            {
                atLeastOne.Add(word.TrimStart('+'));
            }
        }

        return atLeastOne;
    }
}