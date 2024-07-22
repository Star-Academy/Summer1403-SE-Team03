// See https://aka.ms/new-console-template for more information

using phase2;
using phase2.FileManager;
using phase2.Processor;
using phase2.Processor.QueryProcessor;

internal class Program
{
    public static void Main(string[] args)
    {
        String input = Console.ReadLine();
        EngineProcessor.SetInvertedIndexDocx();
        var result = SearchOperation.SearchText(input.ToUpper() ,EngineProcessor.InvertedIndexDocx);
        foreach (var element in result) 
        {
            Console.WriteLine(element);
        }
    }
        
}