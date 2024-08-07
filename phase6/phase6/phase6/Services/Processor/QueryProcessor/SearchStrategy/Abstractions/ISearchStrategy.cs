namespace phase6.Services.Processor.QueryProcessor.SearchStrategy.Abstractions;

public interface ISearchStrategy
{
    IEnumerable<string> ManageSearchStrategy(string inputSearch);
}