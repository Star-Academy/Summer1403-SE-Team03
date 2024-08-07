using phase6.Models.Models;
using phase6.Services.IO.InputManager;
using phase6.Services.Processor.EngineProcessor;
using phase6.Services.Processor.InvertedIndexManager;
using phase6.Services.Processor.PreProcessor;
using phase6.Services.Processor.QueryProcessor.SearchImplemention;
using phase6.Services.Processor.QueryProcessor.SearchImplemention.Abstractions;
using phase6.Services.Processor.QueryProcessor.SearchStrategy.SearchStrategyFactory.Abstractions;

namespace phase6.Services.Processor.QueryProcessor.SearchStrategy.SearchStrategyFactory;

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