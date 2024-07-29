using phase3.Models;

namespace phase3.Processor.QueryProcessor;

public interface ISearchIndexManager
{
    Dictionary<string, List<string>> GetInvertedIndex(List<DataFile> dataFiles);
}