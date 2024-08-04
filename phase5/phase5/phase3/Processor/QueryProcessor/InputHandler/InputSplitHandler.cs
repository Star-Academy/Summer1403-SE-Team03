using System.Text.RegularExpressions;
using phase3.Processor.QueryProcessor.SearchStrategy.IFilterStrategy;

namespace phase3.Processor.QueryProcessor.InputHandler;

public class InputSplitHandler : IInputSplitHandler
{
    private List<string> ExtractSingleWord(string searchInput) 
    {
        string pattern = "([+-| ]\"([^\"]*)\")";
        string singleWords = Regex.Replace(searchInput, pattern, "");
        var splitInput = singleWords.Split(" ").ToList();
        List<string> result = new List<string>();
        foreach (var word in splitInput)
        {
            if (word != "")
            {
                result.Add(word.ToString());
            }
        }

        return result;
    }

    private List<string> ExtractPhrase(string searchInput)
    {
        string signRegex = @"([+-]?)\s*""([^""]*)""";
        string phraseRegex = @"[-+ ]""([^""]*)""";
        Regex sign = new Regex(signRegex);
        Regex phease = new Regex(phraseRegex);
        List<string> phrases = phease.Matches(searchInput)
            .Cast<Match>()
            .Select(match => match.Groups[1].Value)
            .ToList();
        List<string> signs = sign.Matches(searchInput)
            .Cast<Match>()
            .Select(match => match.Groups[1].Value)
            .ToList();
        List<string> result = signs.Zip(phrases, (sign, phrase) => sign + phrase).ToList();
        return result;
    }

    public List<string> TokenizeInput(string inputSearch)
    {
        return ExtractSingleWord(inputSearch).Concat(ExtractPhrase(inputSearch)).ToList();
    }
}