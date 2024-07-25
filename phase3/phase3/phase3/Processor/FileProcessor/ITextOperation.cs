using phase3.Models;

namespace phase3.Processor;

public interface ITextOperation
{
    List<DataFile> Execute(List<DataFile> DataFile);
}