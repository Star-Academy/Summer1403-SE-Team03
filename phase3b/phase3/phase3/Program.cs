using phase3.IO.OutPutManager;
using phase3.Processor.QueryProcessor.SearchStrategy;


internal class Program
{
    public static void Main(string[] args)
    {
        var input = Console.ReadLine();
        var searchStrategy = new SearchStrategy(
            new ContainOneOfWordSearch(),
            new MustIncludeWord(),
            new MustNotContainWord(),
            new SearchQueryParser(),
            new SearchResultsFilter());
        ConsoleOutput consoleOutput = new ConsoleOutput(searchStrategy);
        var results = consoleOutput.OutputProcess(input);
        results.ToList().ForEach(result => Console.WriteLine(result));
    }
}