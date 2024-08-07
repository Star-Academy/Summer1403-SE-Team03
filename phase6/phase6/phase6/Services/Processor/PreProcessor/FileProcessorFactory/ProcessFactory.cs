using phase6.Services.Processor.PreProcessor.Abstractions;
using phase6.Services.Processor.PreProcessor.FileProcessorFactory.Abstractions;

namespace phase6.Services.Processor.PreProcessor.FileProcessorFactory;

public class ProcessFactory : IProcessFactory
{
    public List<ITextOperation> GetOperations()
        {
            return new List<ITextOperation>
            {
                new PunctuationRemover(),
                new ExtraSpaceRemover(),
                new UpperCaseMaker()
            };
        }
}