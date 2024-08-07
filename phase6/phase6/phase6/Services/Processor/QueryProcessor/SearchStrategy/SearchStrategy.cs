using phase6.Models.Models;
using phase6.Services.Processor.QueryProcessor.InputHandler.Abstractions;
using phase6.Services.Processor.QueryProcessor.SearchStrategy.Abstractions;
using phase6.Services.Processor.QueryProcessor.SearchStrategy.SearchStrategyFactory.Abstractions;

namespace phase6.Services.Processor.QueryProcessor.SearchStrategy;

public class SearchStrategy : ISearchStrategy
{
    private readonly ISearchStrategyFactory _searchStrategyFactory;
    private readonly ISearchQueryParser _searchQueryParser;
    private readonly ISearchResultsFilter _searchResultsFilter;
    private readonly IInputSplitHandler _inputSplitHandler;

    public SearchStrategy(ISearchStrategyFactory searchStrategyFactory, ISearchQueryParser searchQueryParser,
        ISearchResultsFilter searchResultsFilter, IInputSplitHandler inputSplitHandler)
    {
        _searchStrategyFactory = searchStrategyFactory;
        _searchQueryParser = searchQueryParser;
        _searchResultsFilter = searchResultsFilter;
        _inputSplitHandler = inputSplitHandler;
    }

    public IEnumerable<string> ManageSearchStrategy(string inputSearch)
    {
        List<string> atLeastOne = new();
        List<string> wordsShouldBe = new();
        List<string> wordsShouldNotBe = new();
        var upperInputSearch = inputSearch.ToUpper();
        _searchQueryParser.ManageInputSearchStrategy(_inputSplitHandler.TokenizeInput(upperInputSearch), out atLeastOne,
            out wordsShouldBe,
            out wordsShouldNotBe);
        var atLeastOneResult = _searchStrategyFactory.GetValueOfKey(QueryConstants.AtLeastOneSign)
            .ProcessOnWords(atLeastOne);
        var wordsShouldBeResult = _searchStrategyFactory.GetValueOfKey(QueryConstants.MustContainSign)
            .ProcessOnWords(wordsShouldBe);
        var wordsShouldNotBeResult = _searchStrategyFactory.GetValueOfKey(QueryConstants.MustNotContainSign)
            .ProcessOnWords(wordsShouldNotBe);

        return _searchResultsFilter.GetResult(atLeastOneResult, wordsShouldBeResult, wordsShouldNotBeResult);
    }

}