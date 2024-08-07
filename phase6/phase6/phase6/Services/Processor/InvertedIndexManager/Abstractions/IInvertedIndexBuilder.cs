using phase6.Models.Models;

namespace phase6.Services.Processor.InvertedIndexManager.Abstractions;

public interface IInvertedIndexBuilder
{
    Dictionary<string, List<string>> BuildInvertedIndex(List<DataFile> docs);
}