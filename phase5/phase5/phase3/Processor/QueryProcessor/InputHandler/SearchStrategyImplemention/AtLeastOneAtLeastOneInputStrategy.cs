using phase3.Models;
using phase3.Processor.QueryProcessor.SearchStrategy.IFilterStrategy;

namespace phase3.Processor.QueryProcessor.SearchStrategy.SearchStrategyImplemention;

public class AtLeastOneAtLeastOneInputStrategy : IAtLeastOneInputStrategy
{
    
    public List<string> Apply(IReadOnlyList<string> inputWords)
    {
        List<string> atLeastOne = new List<string>();
        foreach (string word in inputWords)
        {
            if (word.StartsWith(QueryConstants.AtLeastOneSign))
            {
                atLeastOne.Add(word.TrimStart(Char.Parse(QueryConstants.AtLeastOneSign)));
            }
        }

        return atLeastOne;
    }
}