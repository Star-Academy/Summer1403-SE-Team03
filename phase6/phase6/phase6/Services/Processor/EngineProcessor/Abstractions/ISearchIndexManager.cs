using phase6.Models.Models;

namespace phase6.Services.Processor.EngineProcessor.Abstractions;

public interface ISearchIndexManager
{
    Dictionary<string, List<string>> GetInvertedIndex(List<DataFile> dataFiles);
}