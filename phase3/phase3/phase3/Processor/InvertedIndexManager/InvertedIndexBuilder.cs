using phase3.Models;

namespace phase3.InvertedIndexManager;

public class InvertedIndexBuilder
{
    public static Dictionary<string, List<string>> BuildInvertedIndex(List<DataFile> docs)
    {
        var invertedData = new Dictionary<string, List<string>>();

        foreach (var element in docs)
        {
            var words = element.Data.Split(' ', StringSplitOptions.RemoveEmptyEntries);
            foreach (var elementWord in words)
                if (!invertedData.ContainsKey(elementWord))
                {
                    List<string> values = new() { element.FileName };
                    invertedData.Add(elementWord, values);
                }
                else if (!invertedData[elementWord].Contains(element.FileName))
                {
                    invertedData[elementWord].Add(element.FileName);
                }
        }

        return invertedData;
    }
}