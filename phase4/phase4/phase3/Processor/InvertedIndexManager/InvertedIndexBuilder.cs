using phase3.Models;

namespace phase3.InvertedIndexManager;

public class InvertedIndexBuilder : IInvertedIndexBuilder
{
    public Dictionary<string, List<string>> BuildInvertedIndex(List<DataFile> docs)
    {
        if (docs is null)
        {
            throw new NullReferenceException();
        }
        var invertedData = new Dictionary<string, List<string>>();

        foreach (DataFile element in docs)
        {
            var words = SpiltData(element);
            AddOrUpdateWords(words, invertedData, element);
        }

        return invertedData;
    }

    private void AddOrUpdateWords(List<string> words, Dictionary<string, List<string>> invertedData, DataFile element)
    {
        foreach (string elementWord in words)
        {
            InvertedHandler(invertedData, element, elementWord);
        }
    }

    private void InvertedHandler(Dictionary<string, List<string>> invertedData, DataFile element, string elementWord)
    {
        if (!invertedData.ContainsKey(elementWord))
        {
            invertedData.Add(elementWord, new List<string>() { element.FileName });
        }
        else if (!invertedData[elementWord].Contains(element.FileName))
        {
            invertedData[elementWord].Add(element.FileName);
        }
    }

    private List<string> SpiltData(DataFile element)
    {
        return element.Data.Split(' ', StringSplitOptions.RemoveEmptyEntries).ToList();
    }
}