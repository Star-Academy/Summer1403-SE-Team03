using phase3.Models;
namespace phase3.InvertedIndexManager;
public class InvertedIndexBuilder : IInvertedIndexBuilder
{
    public Dictionary<string, List<string>> BuildInvertedIndex(List<DataFile> docs) 
    {
        var invertedData = new Dictionary<string, List<string>>();

        foreach (DataFile element in docs)
        {
            var words = SpiltData(element);
            foreach (string elementWord in words)
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
        }
        
        return invertedData;
    }
    private List<string> SpiltData(DataFile element)
    {
        return element.Data.Split(' ', StringSplitOptions.RemoveEmptyEntries).ToList();
    }
}