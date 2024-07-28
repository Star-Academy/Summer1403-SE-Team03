using phase3.Models;

namespace phase3.Processor.QueryProcessor;

public interface IEngineProcessor
{
    void SetInvertedIndexDocx(List<DataFile> dataPath);
    Dictionary<string, List<string>> GetInvertedIndex();
}