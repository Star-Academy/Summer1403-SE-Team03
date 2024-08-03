using phase3.Processor.FileProcessorFactory.Abstractions;

namespace phase3.Processor.FileProcessorFactory;

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