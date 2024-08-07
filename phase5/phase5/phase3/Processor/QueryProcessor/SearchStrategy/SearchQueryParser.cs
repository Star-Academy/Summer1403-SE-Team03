using phase3.Exceotions;
using phase3.Processor.QueryProcessor.SearchStrategy.IFilterStrategy;
using phase3.Processor.QueryProcessor.SearchStrategy.SearchStrategyImplemention;

namespace phase3.Processor.QueryProcessor.SearchStrategy;

public class SearchQueryParser : ISearchQueryParser
{
    private readonly IAtLeastOneInputStrategy _atLeastOneInputStrategy;
    private readonly IMustIncludeInputStrategy _mustIncludeInputStrategy;
    private readonly IMustNotContainInputStrategy _mustNotContainInputStrategy;

    public SearchQueryParser(IAtLeastOneInputStrategy atLeastOneInputStrategy, IMustIncludeInputStrategy mustIncludeInputStrategy, IMustNotContainInputStrategy mustNotContainInputStrategy)
    {
        _atLeastOneInputStrategy = atLeastOneInputStrategy;
        _mustIncludeInputStrategy = mustIncludeInputStrategy;
        _mustNotContainInputStrategy = mustNotContainInputStrategy;
    }

    public void ManageInputSearchStrategy(IReadOnlyList<string> splitInput, out List<string> atLeastOne,
        out List<string> wordsShouldBe, out List<string> wordsShouldNotBe)
    {
        atLeastOne = new List<string>(_atLeastOneInputStrategy.Apply(splitInput));
        wordsShouldBe = new List<string>(_mustIncludeInputStrategy.Apply(splitInput));
        wordsShouldNotBe = new List<string>(_mustNotContainInputStrategy.Apply(splitInput));
    }
}