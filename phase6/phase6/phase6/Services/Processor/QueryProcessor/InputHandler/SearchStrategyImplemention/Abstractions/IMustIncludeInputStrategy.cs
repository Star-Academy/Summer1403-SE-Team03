namespace phase6.Services.Processor.QueryProcessor.InputHandler.SearchStrategyImplemention.Abstractions;

public interface IMustIncludeInputStrategy
{
    List<string> Apply(IReadOnlyList<string> inputWords);
}