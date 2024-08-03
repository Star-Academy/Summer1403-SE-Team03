namespace phase3.Processor.QueryProcessor.SearchStrategy;

public interface ISearchQueryParser
{
    void ManageInputSearchStrategy(IReadOnlyList<string> splitInput, out List<string> atLeastOne,
        out List<string> wordsShouldBe, out List<string> wordsShouldNotBe);
}