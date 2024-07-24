﻿
using phase3.Processor.QueryProcessor.SearchStrategy;

internal class Program
{
    public static void Main(string[] args)
    {
        var input = Console.ReadLine();
        var searchStrategy = new SearchStrategy();
        var result = searchStrategy.ManageSearchStrategy(input);
        Console.WriteLine("Count :" + result.Count());
        foreach (var element in result) Console.WriteLine(element);
    }
}