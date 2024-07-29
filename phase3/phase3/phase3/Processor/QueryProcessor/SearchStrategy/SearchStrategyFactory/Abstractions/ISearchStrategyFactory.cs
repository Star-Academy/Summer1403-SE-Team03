namespace phase3.Processor.QueryProcessor.SearchStrategy;

public interface ISearchStrategyFactory
{
    ISearchStrategy GetValueOfKey(string key);
}