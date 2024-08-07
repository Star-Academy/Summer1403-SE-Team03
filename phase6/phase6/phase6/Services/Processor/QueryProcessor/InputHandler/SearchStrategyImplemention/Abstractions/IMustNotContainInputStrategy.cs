namespace phase6.Services.Processor.QueryProcessor.InputHandler.SearchStrategyImplemention.Abstractions;

public interface IMustNotContainInputStrategy
{
    List<string> Apply(IReadOnlyList<string> inputWords);
}