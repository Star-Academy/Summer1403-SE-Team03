using System.Collections;
using System.Runtime.CompilerServices;
using phase3.Models;
using phase3.Processor.FileProcessorFactory;
using phase3.Processor.FileProcessorFactory.Abstractions;

namespace phase3.Processor;

public sealed class FileProcessor : IFileProcessor
{
    public List<DataFile> ProcessDocumentsForIndexing(List<DataFile> docx,IProcessFactory iProcessFactory)
    {
        var operations = iProcessFactory.GetOperations();
        return operations.Aggregate(docx, (current, operation) => operation.Execute(current));
    }
}