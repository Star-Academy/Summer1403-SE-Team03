using phase6.Models.Models;
using phase6.Services.Processor.PreProcessor.Abstractions;

namespace phase6.Services.Processor.PreProcessor;

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