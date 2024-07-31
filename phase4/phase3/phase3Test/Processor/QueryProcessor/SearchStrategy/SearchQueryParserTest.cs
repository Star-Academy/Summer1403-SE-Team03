using phase3.Processor.QueryProcessor.SearchStrategy;

namespace phase3Test.Processor.QueryProcessor.SearchStrategy;

public class SearchQueryParserTest
{
    private readonly SearchQueryParser _sut = new SearchQueryParser();
    [Fact]
    public void ManageInputSearchStrategy_ShouldReturnFilterListStrategies_WhenInputIsValid()
    {
        // Arrange
        var input = new List<string> { "+test1", "test2", "-test3" };
        var expectedAtLeastOne = new List<string> { "test1" };
        var expectedWordsShouldBe = new List<string> { "test2" };
        var expectedWordsShouldNotBe = new List<string> { "test3" };

        // Act
        _sut.ManageInputSearchStrategy(input, out var atLeastOne, out var wordsShouldBe,
            out var wordsShouldNotBe);

        // Assert
        Assert.True(
            atLeastOne.SequenceEqual(expectedAtLeastOne) &&
            wordsShouldBe.SequenceEqual(expectedWordsShouldBe) &&
            wordsShouldNotBe.SequenceEqual(expectedWordsShouldNotBe));
    }
}