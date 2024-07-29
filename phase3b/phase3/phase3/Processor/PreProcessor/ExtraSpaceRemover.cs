using System.Text.RegularExpressions;
using phase3.Models;
using Regex = System.Text.RegularExpressions.Regex;

namespace phase3.Processor;

public class ExtraSpaceRemover : ITextOperation
{
    public List<DataFile> Execute(List<DataFile> docx)
    {
        var result = docx.Select(element => new DataFile
        {
            FileName = element.FileName,
            Data = Regex.Replace(element.Data, RegexPatternConst._patternExtraSpace, " ")
        }).ToList();
        return result;
    }
}