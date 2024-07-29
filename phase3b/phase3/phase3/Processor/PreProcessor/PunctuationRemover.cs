using System.Text.RegularExpressions;
using phase3.Models;

namespace phase3.Processor;

public class PunctuationRemover : ITextOperation
{
    public List<DataFile> Execute(List<DataFile> docx)
    {
        var regex = new Regex(RegexPatternConst._patternPunctuation);
        var result = docx.Select(element => new DataFile
        {
            FileName = element.FileName,
            Data = string.Join(" ", regex.Split(element.Data))
        }).ToList();
        return result;
    }
}