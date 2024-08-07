using phase6.Models.Models;
using phase6.Services.Processor.PreProcessor.Abstractions;
using Regex = System.Text.RegularExpressions.Regex;

namespace phase6.Services.Processor.PreProcessor;

public class ExtraSpaceRemover : ITextOperation
{
    public List<DataFile> Execute(List<DataFile> docs)
    {
        if (docs is null)
        {
            throw new NullReferenceException(nameof(docs));
        }
        var result = docs.Select(element => new DataFile
        {
            FileName = element.FileName,
            Data = Regex.Replace(element.Data, RegexPatternConst.PatternExtraSpace, " ")
        }).ToList();
        return result;
    }
}