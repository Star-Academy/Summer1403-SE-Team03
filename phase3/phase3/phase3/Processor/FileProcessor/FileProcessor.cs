using phase3.Models;

namespace phase3.Processor;

public sealed class FileProcessor
{
    public static List<DataFile> ProcessDocumentsForIndexing(List<DataFile> docx)
    {
        return UpperCaseMaker.MakeUpperCase(docx).RemovePunctuation().RemoveExtraSpace();
    }
}