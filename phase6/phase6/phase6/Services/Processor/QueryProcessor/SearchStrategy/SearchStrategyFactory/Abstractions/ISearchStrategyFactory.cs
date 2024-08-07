using phase6.Services.Processor.QueryProcessor.SearchImplemention.Abstractions;

namespace phase6.Services.Processor.QueryProcessor.SearchStrategy.SearchStrategyFactory.Abstractions;

public interface ISearchStrategyFactory
{
    IInputManagement GetValueOfKey(string key);
}