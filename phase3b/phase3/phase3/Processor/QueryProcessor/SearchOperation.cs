using phase3.FileManager;
using phase3.InvertedIndexManager;

namespace phase3.Processor.QueryProcessor;

public class SearchOperation
{
    public static List<string> SearchText(string input)
    {
        TextFileReader textFileReader = new TextFileReader();
        EngineProcessor engineProcessor = new EngineProcessor(new FileProcessor() , new InvertedIndexBuilder());
        // کامنت گزاشتم که ببینید کانستراکتور انجین پراسسر داره یدونه file processor نیو میکنه و آیا این اوکیه ؟ یا باید به نحو دیگ ای باشه ؟
        engineProcessor.SetInvertedIndexDocx(textFileReader.ReadFile(Resources.dataPath));
        if (engineProcessor.InvertedIndexDictionary.TryGetValue(input, out List<string> documents))
            return documents;
        return new List<string>();
    }
}