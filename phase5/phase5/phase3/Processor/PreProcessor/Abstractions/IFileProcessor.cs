using phase3.Models;
using phase3.Processor.FileProcessorFactory.Abstractions;

namespace phase3.Processor;

public interface IFileProcessor
{
    List<DataFile> ProcessDocumentsForIndexing(List<DataFile> docx , IProcessFactory processFactory);
}