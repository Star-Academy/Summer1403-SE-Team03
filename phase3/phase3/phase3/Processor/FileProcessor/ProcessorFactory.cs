namespace phase3.Processor;

public class ProcessorFactory
{
    public static ITextOperation Creat (FileProcessorMethod fileProcessorMethod)
    {
        switch (fileProcessorMethod)
        {
            case FileProcessorMethod.UpperCaseMaker :
                return new UpperCaseMaker();
            break;
            case FileProcessorMethod.ExtraSpaceRemover:
                return new ExtraSpaceRemover();
            break;
            case FileProcessorMethod.PunctuationRemover:
                return new PunctuationRemover();
            default:
                throw new NotSupportedException();
        }
    }
}