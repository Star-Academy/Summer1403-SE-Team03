using phase3.Models;

namespace phase3.InvertedIndexManager;

public interface IInvertedIndexBuilder
{
    Dictionary<string, List<string>> BuildInvertedIndex(List<DataFile> docs);
}