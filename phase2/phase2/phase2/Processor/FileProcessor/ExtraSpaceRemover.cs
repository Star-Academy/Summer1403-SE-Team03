using System.Text.RegularExpressions;
using phase2.Models;

namespace phase2.Processor;

public class ExtraSpaceRemover
{
    public static List<DataFile> RemoveExtraSpace(List<DataFile> docx)
    {
        var pattern = @"\s+";
        var result = new List<DataFile>();
        foreach (var element in docx)
        {
            result.Add(new DataFile(element.FileName, Regex.Replace(element.Data, pattern, " ")));
        }
        return result;
    }
}