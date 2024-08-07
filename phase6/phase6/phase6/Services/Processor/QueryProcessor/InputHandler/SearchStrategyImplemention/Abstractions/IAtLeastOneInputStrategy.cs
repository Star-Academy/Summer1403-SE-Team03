namespace phase6.Services.Processor.QueryProcessor.InputHandler.SearchStrategyImplemention.Abstractions;

public interface IAtLeastOneInputStrategy
{
    List<string> Apply(IReadOnlyList<string> inputWords);
}