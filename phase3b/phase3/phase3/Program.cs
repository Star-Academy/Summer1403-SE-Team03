using phase3.FileManager;
using phase3.InvertedIndexManager;
using phase3.IO.OutPutManager;
using phase3.Processor;
using phase3.Processor.QueryProcessor;
using phase3.Processor.QueryProcessor.SearchStrategy;


internal class Program
{
    public static void Main(string[] args)
    {
        var input = Console.ReadLine();
        var searchStrategy = new SearchStrategy(
            new ContainOneOfWordSearch(new SearchOperation(new TextFileReader(),
                new EngineProcessor(new FileProcessor(), new InvertedIndexBuilder()))),
            new MustIncludeWord(new SearchOperation(new TextFileReader(),
                new EngineProcessor(new FileProcessor(), new InvertedIndexBuilder()))),
            new MustNotContainWord(new SearchOperation(new TextFileReader(),
                new EngineProcessor(new FileProcessor(), new InvertedIndexBuilder()))),
            new SearchQueryParser(),
            new SearchResultsFilter());
        ConsoleOutput consoleOutput = new ConsoleOutput(searchStrategy);
        var results = consoleOutput.OutputProcess(input);
        results.ToList().ForEach(result => Console.WriteLine(result));
    }
}