using phase6.Models.Models;
using phase6.Services.Processor.PreProcessor.Abstractions;
using phase6.Services.Processor.PreProcessor.FileProcessorFactory.Abstractions;

namespace phase6.Services.Processor.PreProcessor;

public sealed class FileProcessor : IFileProcessor
{
    public List<DataFile> ProcessDocumentsForIndexing(List<DataFile> docx,IProcessFactory iProcessFactory)
    {
        var operations = iProcessFactory.GetOperations();
        return operations.Aggregate(docx, (current, operation) => operation.Execute(current));
    }
}