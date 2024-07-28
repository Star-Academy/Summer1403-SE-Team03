using System.Collections;
using System.Runtime.CompilerServices;
using phase3.Models;

namespace phase3.Processor;

public sealed class FileProcessor
{
    public static List<DataFile> ProcessDocumentsForIndexing(List<DataFile> docx)
    {
        var operations = new List<ITextOperation>
            { new ExtraSpaceRemover(), new PunctuationRemover(), new UpperCaseMaker() };
        List<DataFile> result = docx;
        foreach (var operation in operations)
        {
            result = operation.Execute(result);
        }

        return result;
    }
}