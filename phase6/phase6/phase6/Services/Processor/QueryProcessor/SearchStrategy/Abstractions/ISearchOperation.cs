namespace phase6.Services.Processor.QueryProcessor.SearchStrategy.Abstractions;

public interface ISearchOperation
{
    List<string> SearchText(string input);
}