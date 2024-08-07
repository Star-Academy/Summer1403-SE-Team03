using phase6.Models.Models;
using phase6.Services.Processor.QueryProcessor.InputHandler.SearchStrategyImplemention.Abstractions;

namespace phase6.Services.Processor.QueryProcessor.InputHandler.SearchStrategyImplemention;

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