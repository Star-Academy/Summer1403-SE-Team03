using phase3.Models;

namespace phase3.Processor.QueryProcessor.SearchStrategy;

public class SearchStrategy : ISearchStrategy
{
    private readonly ISearchStrategyFactory _searchStrategyFactory;
    private readonly ISearchQueryParser _searchQueryParser;
    private readonly ISearchResultsFilter _searchResultsFilter;

    public SearchStrategy(ISearchStrategyFactory searchStrategyFactory, ISearchQueryParser searchQueryParser,
        ISearchResultsFilter searchResultsFilter)
    {
        _searchStrategyFactory = searchStrategyFactory;
        _searchQueryParser = searchQueryParser;
        _searchResultsFilter = searchResultsFilter;
    }

    public IEnumerable<string> ManageSearchStrategy(string inputSearch)
    {
        List<string> atLeastOne = new();
        List<string> wordsShouldBe = new();
        List<string> wordsShouldNotBe = new();
        var upperInputSearch = inputSearch.ToUpper();
        _searchQueryParser.ManageInputSearchStrategy(SplitSearchInput(upperInputSearch), out atLeastOne,
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

    private List<string> SplitSearchInput(string searchInput)
    {
        var splitSearchInput = searchInput.Split(" ").ToList();
        return splitSearchInput;
    }
}