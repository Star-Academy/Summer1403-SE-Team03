using System.Text.RegularExpressions;
using phase3.Models;

namespace phase3.Processor;

public class PunctuationRemover : ITextOperation
{
    public List<DataFile> Execute(List<DataFile> docx)
    {
        const string pattern = @"[^A-Za-z0-9]";
        var regex = new Regex(pattern);
        var result = docx.Select(element => new DataFile
        {
            FileName = element.FileName,
            Data = string.Join(" ", regex.Split(element.Data))
        }).ToList();
        return result;
    }
}