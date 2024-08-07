using System.Text.RegularExpressions;
using phase6.Models.Models;
using phase6.Services.Processor.PreProcessor.Abstractions;

namespace phase6.Services.Processor.PreProcessor;

public class PunctuationRemover : ITextOperation
{
    public List<DataFile> Execute(List<DataFile> docx)
    {
        var regex = new Regex(RegexPatternConst.PatternPunctuation);
        var result = docx.Select(element => new DataFile
        {
            FileName = element.FileName,
            Data = string.Join(" ", regex.Split(element.Data))
        }).ToList();
        return result;
    }
}