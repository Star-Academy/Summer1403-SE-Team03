namespace phase3.Processor.FileProcessorFactory.Abstractions;

public interface IProcessFactory
{
    List<ITextOperation> GetOperations();
}