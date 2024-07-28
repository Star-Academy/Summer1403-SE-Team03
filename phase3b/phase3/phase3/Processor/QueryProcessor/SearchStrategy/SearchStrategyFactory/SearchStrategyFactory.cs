using phase3.FileManager;
using phase3.InvertedIndexManager;
using phase3.Models;

namespace phase3.Processor.QueryProcessor.SearchStrategy;

public class SearchStrategyFactory : ISearchStrategyFactory
{
    private readonly IReadOnlyDictionary<string, ISearchStrategy> _strategies;
    
    public SearchStrategyFactory()
    {
        _strategies = new Dictionary<string, ISearchStrategy>
        {
            {
                QueryConstants.atLeastOneSign, new ContainOneOfWordSearch(
                    new SearchOperation(
                        new TextFileReader(),
                        new EngineProcessor(new FileProcessor(), new InvertedIndexBuilder())))
            },
            {
                QueryConstants.mustContainSign,
                new MustIncludeWord(new SearchOperation(new TextFileReader(),
                    new EngineProcessor(new FileProcessor(), new InvertedIndexBuilder())))
            },
            {
                QueryConstants.mustNotContainSign,
                new MustNotContainWord(new SearchOperation(new TextFileReader(),
                    new EngineProcessor(new FileProcessor(), new InvertedIndexBuilder())))
            }
        };
    }

    public ISearchStrategy GetValueOfKey(string key)
    {
        return _strategies[key];
    }
}