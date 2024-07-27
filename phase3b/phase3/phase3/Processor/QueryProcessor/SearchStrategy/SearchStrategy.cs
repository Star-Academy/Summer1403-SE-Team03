
namespace phase3.Processor.QueryProcessor.SearchStrategy;

public class SearchStrategy
{
    private readonly Dictionary<string, ISearchStrategy> _strategies;
    private readonly ISearchStrategy _containOneOfWordSearch;
    private readonly ISearchStrategy _mustIncludeWord;
    private readonly ISearchStrategy _mustNotContainWord;
    private readonly SearchQueryParser _searchQueryParser;
    private readonly SearchResultsFilter _searchResultsFilter;
    
    public SearchStrategy(ISearchStrategy containOneOfWordSearch , ISearchStrategy mustIncludeWord , ISearchStrategy  mustNotContainWord
        ,SearchQueryParser searchQueryParser , SearchResultsFilter searchResultsFilter)
    {
        _strategies = new Dictionary<string, ISearchStrategy>
        {
            { "atLeastOne", new ContainOneOfWordSearch() },
            { "wordsShouldBe", new MustIncludeWord() },
            { "wordsShouldNotBe", new MustNotContainWord() }
        };
        _containOneOfWordSearch = containOneOfWordSearch;
        _mustIncludeWord = mustIncludeWord;
        _mustNotContainWord = mustNotContainWord;
        _searchQueryParser = searchQueryParser;
        _searchResultsFilter = searchResultsFilter;
    }

    public IEnumerable<string> ManageSearchStrategy(string inputSearch)
    {
        List<string> atLeastOne = new();
        List<string> wordsShouldBe = new();
        List<string> wordsShouldNotBe = new();
        var upperInputSearch = inputSearch.ToUpper();
        _searchQueryParser.ManageInputSearchStrategy(SplitSearchInput(upperInputSearch), out atLeastOne, out wordsShouldBe,
            out wordsShouldNotBe);
        var atLeastOneResult = _strategies["atLeastOne"].ProcessOnWords(atLeastOne);
        var wordsShouldBeResult = _strategies["wordsShouldBe"].ProcessOnWords(wordsShouldBe);
        var wordsShouldNotBeResult = _strategies["wordsShouldNotBe"].ProcessOnWords(wordsShouldNotBe);
        return _searchResultsFilter.GetResult(atLeastOneResult, wordsShouldBeResult, wordsShouldNotBeResult);
    }
    private List<string> SplitSearchInput(string searchInput)
    {
        var splitSearchInput = searchInput.Split(" ").ToList();
        return splitSearchInput;
    }
}