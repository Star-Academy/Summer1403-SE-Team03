namespace phase3.Processor.QueryProcessor.SearchStrategy;

public interface IInputManagement
{
    List<string> ProcessOnWords(IReadOnlyList<string> input);
}