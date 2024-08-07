namespace phase3.Processor.QueryProcessor.SearchStrategy.IFilterStrategy;

public interface IInputSplitHandler
{
    List<string> TokenizeInput(string inputSearch);
}