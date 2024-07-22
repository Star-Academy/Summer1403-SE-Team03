using phase2.Models;

namespace phase2.Processor;

public class UpperCase
{
    public static List<DataFile> MakeUppercase(List<DataFile> docx)
    {
        var uppercaseOutput = new List<DataFile>();
        foreach (var element in docx)
        {
            uppercaseOutput.Add(new DataFile(element.FileName , element.Data.ToUpper()));
        }

        return uppercaseOutput;
    }
}