using phase3.Models;

namespace phase3.Processor;

public interface IFileProcessor
{
    List<DataFile> ProcessDocumentsForIndexing(List<DataFile> docx);
}