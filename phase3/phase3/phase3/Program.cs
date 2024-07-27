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
        var result = searchStrategy.ManageSearchStrategy(input);
        foreach (var element in result) Console.WriteLine(element);
    }
}