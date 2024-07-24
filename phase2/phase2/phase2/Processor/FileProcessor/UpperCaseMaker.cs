using phase2.Models;

namespace phase2.Processor;

public static class UpperCaseMaker
{
    public static List<DataFile> MakeUpperCase(this List<DataFile> docx)
    {
        var uppercaseOutput = docx.Select(element => new DataFile
        {
            FileName = element.FileName,
            Data = element.Data.ToUpper()
        }).ToList();

        return uppercaseOutput;
    }
}