using phase3.Processor.QueryProcessor.SearchStrategy.IFilterStrategy;
using phase3.Processor.QueryProcessor.SearchStrategy.SearchStrategyImplemention;

namespace phase3.Processor.QueryProcessor.SearchStrategy;

public class SearchStrategy
{
    private readonly Dictionary<string, ISearchStrategy> _strategies;

    public SearchStrategy()
    {
        _strategies = new Dictionary<string, ISearchStrategy>
        {
            { "atLeastOne", new ContainOneOfWordSearch() },
            { "wordsShouldBe", new MustIncludeWord() },
            { "wordsShouldNotBe", new MustNotContainWord() }
        };
    }

    public IEnumerable<string> ManageSearchStrategy(string inputSearch)
    {
        List<string> atLeastOne = new();
        List<string> wordsShouldBe = new();
        List<string> wordsShouldNotBe = new();
        var upperInputSearch = MakeUpperSearchInput(inputSearch);
        ManageInputSearchStrategy(SplitSearchInput(upperInputSearch), out atLeastOne, out wordsShouldBe,
            out wordsShouldNotBe);
        var atLeastOneResult = _strategies["atLeastOne"].ProcessOnWords(atLeastOne);
        var wordsShouldBeResult = _strategies["wordsShouldBe"].ProcessOnWords(wordsShouldBe);
        var wordsShouldNotBeResult = _strategies["wordsShouldNotBe"].ProcessOnWords(wordsShouldNotBe);
        return GetResult(atLeastOneResult, wordsShouldBeResult, wordsShouldNotBeResult);
    }

    private string MakeUpperSearchInput(string searchInput)
    {
        return searchInput.ToUpper();
    }

    private List<string> SplitSearchInput(string searchInput)
    {
        var splitSearchInput = searchInput.Split(" ").ToList();
        return splitSearchInput;
    }

    private void ManageInputSearchStrategy(List<string> splitInput, out List<string> atLeastOne,
        out List<string> wordsShouldBe, out List<string> wordsShouldNotBe)
    {
        atLeastOne = new List<string>();
        wordsShouldBe = new List<string>();
        wordsShouldNotBe = new List<string>();
        
        var strategies = new Dictionary<char, IFilterSearchStrategy>
        {
            { '+', new AtLeastOneFilterStrategy() },
            { '-', new MustNotContainFilterStrategy() }
        };

        var defaultStrategy = new MustIncludeFilterStrategy();

        foreach (var element in splitInput)
        {
            var firstChar = element.ElementAt(0);
            if (strategies.TryGetValue(firstChar, out var strategy))
            {
                strategy.Apply(element, atLeastOne, wordsShouldBe, wordsShouldNotBe);
            }
            else
            {
                defaultStrategy.Apply(element, atLeastOne, wordsShouldBe, wordsShouldNotBe);
            }
        }
    }

    private IEnumerable<string> GetResult(List<string> atLeastOneResult, List<string> wordsShouldBeResult,
        List<string> wordsShouldNotBeResult)
    {
        if (atLeastOneResult.Count == 0)
            return wordsShouldBeResult.Except(wordsShouldNotBeResult).ToList();
        if (wordsShouldBeResult.Count == 0)
            return atLeastOneResult.Except(wordsShouldNotBeResult).ToList();
        return atLeastOneResult.Intersect(wordsShouldBeResult).Except(wordsShouldNotBeResult).ToList();
    }
}