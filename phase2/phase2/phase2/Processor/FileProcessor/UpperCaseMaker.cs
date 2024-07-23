using System.Collections.Generic;
using phase2.Models;

namespace phase2.Processor;

public static class UpperCaseMaker
{
    public static List<DataFile> MakeUpperCase(this List<DataFile> docx)
    {
        var uppercaseOutput = new List<DataFile>();
        foreach (var element in docx)
            uppercaseOutput.Add(new DataFile { FileName = element.FileName, Data = element.Data.ToUpper() });


        return uppercaseOutput;
    }
}