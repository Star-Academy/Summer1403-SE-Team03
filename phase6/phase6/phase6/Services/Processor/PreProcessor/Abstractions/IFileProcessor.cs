using phase6.Models.Models;
using phase6.Services.Processor.PreProcessor.FileProcessorFactory.Abstractions;

namespace phase6.Services.Processor.PreProcessor.Abstractions;

public interface IFileProcessor
{
    List<DataFile> ProcessDocumentsForIndexing(List<DataFile> docx , IProcessFactory processFactory);
}