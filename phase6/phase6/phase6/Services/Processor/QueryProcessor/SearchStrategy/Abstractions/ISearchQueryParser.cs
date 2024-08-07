namespace phase6.Services.Processor.QueryProcessor.SearchStrategy.Abstractions;

public interface ISearchQueryParser
{
    void ManageInputSearchStrategy(IReadOnlyList<string> splitInput, out List<string> atLeastOne,
        out List<string> wordsShouldBe, out List<string> wordsShouldNotBe);
}