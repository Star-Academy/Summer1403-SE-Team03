using System.Collections.Generic;
using System.Runtime.InteropServices.JavaScript;

namespace phase2.Processor.QueryProcessor;

public class SearchOperation
{
    public static List<string> SearchText(string input)
    {
        if (EngineProcessor.Instance.InvertedIndexDictionary.TryGetValue(input, out List<string> documents))
        {
            return documents;
        }
        else
        {
            return new List<string>();
        }
    }
}