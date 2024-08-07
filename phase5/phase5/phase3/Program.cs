using phase3.IO.OutPutManager;
using phase3.Processor.QueryProcessor.InputHandler;
using phase3.Processor.QueryProcessor.SearchStrategy;
using phase3.Processor.QueryProcessor.SearchStrategy.SearchStrategyImplemention;


internal class Program
{
    public static void Main(string[] args)
    {
        var input = Console.ReadLine();
        var searchStrategy = new SearchStrategy(new SearchStrategyFactory(),
            new SearchQueryParser(new AtLeastOneAtLeastOneInputStrategy(), new MustIncludeInputStrategy(),
                new MustNotContainInputStrategy()),
            new SearchResultsFilter(), new InputSplitHandler());
        ConsoleOutput consoleOutput = new ConsoleOutput(searchStrategy);
        var results = consoleOutput.OutputProcess(input);
        results.ToList().ForEach(result => Console.WriteLine(result));
    }
}