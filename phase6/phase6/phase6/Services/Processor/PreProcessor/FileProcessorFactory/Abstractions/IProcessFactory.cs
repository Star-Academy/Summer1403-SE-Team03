using phase6.Services.Processor.PreProcessor.Abstractions;

namespace phase6.Services.Processor.PreProcessor.FileProcessorFactory.Abstractions;

public interface IProcessFactory
{
    List<ITextOperation> GetOperations();
}