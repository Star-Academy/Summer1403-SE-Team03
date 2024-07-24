using phase3.Models;

namespace phase3.Processor;

public class UpperCaseMaker : ITextOperation
{
    public List<DataFile> Execute(List<DataFile> docx)
    {
        var uppercaseOutput = docx.Select(element => new DataFile
        {
            FileName = element.FileName,
            Data = element.Data.ToUpper()
        }).ToList();

        return uppercaseOutput;
    }
}