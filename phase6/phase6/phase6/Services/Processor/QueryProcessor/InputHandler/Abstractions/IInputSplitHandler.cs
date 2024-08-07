namespace phase6.Services.Processor.QueryProcessor.InputHandler.Abstractions;

public interface IInputSplitHandler
{
    List<string> TokenizeInput(string inputSearch);
}