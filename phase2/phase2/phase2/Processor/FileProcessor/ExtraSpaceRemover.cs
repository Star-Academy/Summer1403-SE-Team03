using System.Collections.Generic;
using System.Text.RegularExpressions;
using phase2.Models;

namespace phase2.Processor;

public static class ExtraSpaceRemover
{
    public static List<DataFile> RemoveExtraSpace(this List<DataFile> docx)
    {
        var pattern = @"\s+";
        var result = new List<DataFile>();
        foreach (var element in docx)
        {
            result.Add(new DataFile { FileName = element.FileName, Data = Regex.Replace(element.Data, pattern, " ") });
        }
        return result;
    }
}