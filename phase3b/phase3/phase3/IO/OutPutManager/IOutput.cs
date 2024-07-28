using phase3.Processor.QueryProcessor.SearchStrategy;

namespace phase3.IO.OutPutManager;

public interface IOutput<T>
{
    T OutputProcess(string input);
}