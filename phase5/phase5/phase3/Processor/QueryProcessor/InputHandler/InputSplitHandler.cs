using System.Text.RegularExpressions;
using phase3.Models;
using phase3.Processor.QueryProcessor.SearchStrategy.IFilterStrategy;

namespace phase3.Processor.QueryProcessor.InputHandler;

public class InputSplitHandler : IInputSplitHandler
{
    private List<string> ExtractSingleWord(string searchInput)
    {
        string singleWords = Regex.Replace(searchInput, RegexPatternConst.ExtractSingle, "");
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
        Regex sign = new Regex(RegexPatternConst.SignRegex);
        Regex phease = new Regex(RegexPatternConst.PhraseRegex);
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