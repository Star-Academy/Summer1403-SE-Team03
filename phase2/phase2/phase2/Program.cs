// See https://aka.ms/new-console-template for more information

using phase2;
using phase2.FileManager;
using phase2.Processor;
using phase2.Processor.QueryProcessor;
using phase2.Processor.QueryProcessor.SearchStrategy;

internal class Program
{
    public static void Main(string[] args)
    {
        String input = Console.ReadLine();
        SearchStrategy searchStrategy = new SearchStrategy();
        var result = searchStrategy.ManageSearchStrategy(input);
        foreach (var element in result) 
        {
            Console.WriteLine(element);
        }
    }
        
}