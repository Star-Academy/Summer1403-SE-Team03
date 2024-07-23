using System.Text.RegularExpressions;
using phase2.Models;

namespace phase2.Processor;

public static class ExtraSpaceRemover
{
    public static List<DataFile> RemoveExtraSpace(this List<DataFile> docx)
    {
        const string pattern = @"\s+";
        var result = docx.Select(element => new DataFile
        {
            FileName = element.FileName,
            Data = Regex.Replace(element.Data, pattern, " ")
        }).ToList();
        return result;
    }
}