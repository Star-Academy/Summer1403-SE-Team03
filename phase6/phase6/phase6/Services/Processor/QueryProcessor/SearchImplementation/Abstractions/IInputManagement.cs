namespace phase6.Services.Processor.QueryProcessor.SearchImplemention.Abstractions;

public interface IInputManagement
{
    List<string> ProcessOnWords(IReadOnlyList<string> input);
}