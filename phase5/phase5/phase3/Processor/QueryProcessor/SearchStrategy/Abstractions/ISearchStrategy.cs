namespace phase3.Processor.QueryProcessor.SearchStrategy;

public interface ISearchStrategy
{
    IEnumerable<string> ManageSearchStrategy(string inputSearch);
}