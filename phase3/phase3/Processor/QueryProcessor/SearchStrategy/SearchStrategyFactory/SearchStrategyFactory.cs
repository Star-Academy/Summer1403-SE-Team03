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
                QueryConstants.AtLeastOneSign, new ContainOneOfWordSearch(
                    new SearchOperation(
                        new TextFileReader(),
                        new SearchIndexManager(new FileProcessor(), new InvertedIndexBuilder())))
            },
            {
                QueryConstants.MustContainSign,
                new MustIncludeWord(new SearchOperation(new TextFileReader(),
                    new SearchIndexManager(new FileProcessor(), new InvertedIndexBuilder())))
            },
            {
                QueryConstants.MustNotContainSign,
                new MustNotContainWord(new SearchOperation(new TextFileReader(),
                    new SearchIndexManager(new FileProcessor(), new InvertedIndexBuilder())))
            }
        };
    }

    public ISearchStrategy GetValueOfKey(string key)
    {
        return _strategies[key];
    }
}