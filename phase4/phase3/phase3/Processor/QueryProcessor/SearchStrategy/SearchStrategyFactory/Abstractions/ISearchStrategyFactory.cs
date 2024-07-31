namespace phase3.Processor.QueryProcessor.SearchStrategy;

public interface ISearchStrategyFactory
{
    IInputManagement GetValueOfKey(string key);
}