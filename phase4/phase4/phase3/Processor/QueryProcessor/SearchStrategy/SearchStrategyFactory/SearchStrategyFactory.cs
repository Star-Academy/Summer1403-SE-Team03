using phase3.FileManager;
using phase3.InvertedIndexManager;
using phase3.Models;

namespace phase3.Processor.QueryProcessor.SearchStrategy;

public class SearchStrategyFactory : ISearchStrategyFactory
{
    private readonly IReadOnlyDictionary<string, IInputManagement> _strategies;
    private readonly ContainOneOfWordSearch _containOneOfWordSearch;
    private readonly SearchOperation _searchOperation;
    private readonly TextFileReader _textFileReader;
    private readonly SearchIndexManager _searchIndexManager;
    private readonly FileProcessor _fileProcessor;
    private readonly InvertedIndexBuilder _invertedIndexBuilder;
    private readonly MustIncludeWord _mustIncludeWord;
    private readonly MustNotContainWord _mustNotContainWord;


    public SearchStrategyFactory()
    {
        _fileProcessor = new FileProcessor();
        _invertedIndexBuilder = new InvertedIndexBuilder();
        _textFileReader = new TextFileReader();
        _searchIndexManager = new SearchIndexManager(_fileProcessor, _invertedIndexBuilder);
        _searchOperation = new SearchOperation(_textFileReader, _searchIndexManager);
        _containOneOfWordSearch = new ContainOneOfWordSearch(_searchOperation);
        _mustIncludeWord = new MustIncludeWord(_searchOperation);
        _mustNotContainWord = new MustNotContainWord(_searchOperation);
        _strategies = new Dictionary<string, IInputManagement>
        {
            {
                QueryConstants.AtLeastOneSign, _containOneOfWordSearch
            },
            {
                QueryConstants.MustContainSign, _mustIncludeWord
            },
            {
                QueryConstants.MustNotContainSign, _mustNotContainWord
            }
        };
    }

    public IInputManagement GetValueOfKey(string key)
    {
        return _strategies[key];
    }
}