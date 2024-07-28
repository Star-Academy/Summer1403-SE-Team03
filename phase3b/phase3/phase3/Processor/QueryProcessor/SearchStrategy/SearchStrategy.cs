using phase3.FileManager;
using phase3.InvertedIndexManager;
using phase3.Models;

namespace phase3.Processor.QueryProcessor.SearchStrategy;

public class SearchStrategy
{
    private readonly ISearchStrategyFactory _searchStrategyFactory;
    private readonly SearchQueryParser _searchQueryParser;
    private readonly SearchResultsFilter _searchResultsFilter;

    public SearchStrategy(ISearchStrategyFactory searchStrategyFactory , SearchQueryParser searchQueryParser , SearchResultsFilter searchResultsFilter )
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
        var atLeastOneResult = _searchStrategyFactory.GetValueOfKey(QueryConstants.atLeastOneSign).ProcessOnWords(atLeastOne);
        var wordsShouldBeResult =_searchStrategyFactory.GetValueOfKey(QueryConstants.mustContainSign).ProcessOnWords(wordsShouldBe);
        var wordsShouldNotBeResult = _searchStrategyFactory.GetValueOfKey(QueryConstants.mustNotContainSign).ProcessOnWords(wordsShouldNotBe);

        return _searchResultsFilter.GetResult(atLeastOneResult, wordsShouldBeResult, wordsShouldNotBeResult);
    }

    private List<string> SplitSearchInput(string searchInput)
    {
        var splitSearchInput = searchInput.Split(" ").ToList();
        return splitSearchInput;
    }
}