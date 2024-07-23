using System.Collections.Generic;
using phase2.Models;

namespace phase2.Processor;

public sealed class FileProcessor
{
    public static List<DataFile> ProcessDocumentsForIndexing(List<DataFile> docx)
    {
        return UpperCase.MakeUppercase(docx).RemovePunctuation().RemoveExtraSpace();
    }
}