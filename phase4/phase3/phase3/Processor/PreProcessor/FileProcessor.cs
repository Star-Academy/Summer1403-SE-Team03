using System.Collections;
using System.Runtime.CompilerServices;
using phase3.Models;

namespace phase3.Processor;

public sealed class FileProcessor : IFileProcessor
{
    public List<DataFile> ProcessDocumentsForIndexing(List<DataFile> docx)
    {
        var operations = new List<ITextOperation>
            { new PunctuationRemover(), new ExtraSpaceRemover(), new UpperCaseMaker() };

        return operations.Aggregate(docx, (current, operation) => operation.Execute(current));
    }
}