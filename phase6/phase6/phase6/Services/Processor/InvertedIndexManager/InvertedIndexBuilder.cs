using phase6.Models.Models;
using phase6.Services.Processor.InvertedIndexManager.Abstractions;

namespace phase6.Services.Processor.InvertedIndexManager;

public class InvertedIndexBuilder : IInvertedIndexBuilder
{
    private const int MaxPhraseWordCount = 4;
    public Dictionary<string, List<string>> BuildInvertedIndex(List<DataFile> docs)
    {
        if (docs is null)
        {
            throw new NullReferenceException(nameof(docs));
        }

        var invertedData = new Dictionary<string, List<string>>();

        foreach (DataFile element in docs)
        {
            var words = SpiltData(element);
            for (int length = 1; length <= MaxPhraseWordCount; length++)
            {
                for (int start = 0; start <= words.Count - length; start++)
                {
                    InvertedHandler(invertedData, element, start, length, words);
                }
            }
        }

        return invertedData;
    }

    private void InvertedHandler(Dictionary<string, List<string>> invertedData, DataFile element, int start, int length,
        List<string> words)
    {
        var phrase = string.Join(" ", words.Skip(start).Take(length));

        if (!invertedData.ContainsKey(phrase))
        {
            invertedData.Add(phrase, new List<string>() { element.FileName });
        }
        else if (!invertedData[phrase].Contains(element.FileName))
        {
            invertedData[phrase].Add(element.FileName);
        }
    }

    private List<string> SpiltData(DataFile element)
    {
        return element.Data.Split(' ', StringSplitOptions.RemoveEmptyEntries).ToList();
    }
}