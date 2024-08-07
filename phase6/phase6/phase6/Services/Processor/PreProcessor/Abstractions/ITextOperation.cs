using phase6.Models.Models;

namespace phase6.Services.Processor.PreProcessor.Abstractions;

public interface ITextOperation
{
    List<DataFile> Execute(List<DataFile> DataFile);
}