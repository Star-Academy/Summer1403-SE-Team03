using System.Collections.Generic;
using phase2.Models;

namespace phase2.Processor;

public sealed class FileProcessor
{
    public static List<DataFile> ProcessDocumentsForIndexing(List<DataFile> docx)
    {
        return StopWordRemover.RemoveStopWord(
            ExtraSpaceRemover.RemoveExtraSpace(PunctuationRemover.RemovePunctuation(UpperCase.MakeUppercase(docx))));
    }
}