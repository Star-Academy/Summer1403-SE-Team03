using phase3.Models;

namespace phase3.InvertedIndexManager;

public class InvertedIndexBuilder
{
    public static Dictionary<string, List<string>> BuildInvertedIndex(List<DataFile> docs)
    {
        var invertedData = new Dictionary<string, List<string>>();
        foreach (var doc in docs)
        {
            foreach (var elementWord in doc.Data.Split(' ', StringSplitOptions.RemoveEmptyEntries))
            {
                if (!invertedData.TryGetValue(elementWord, out var elementValue))
                    invertedData.Add(elementWord, [doc.FileName]);
                else if (!invertedData[elementWord].Contains(doc.FileName)) elementValue.Add(doc.FileName);
            }
        }

        return invertedData;
    }
}