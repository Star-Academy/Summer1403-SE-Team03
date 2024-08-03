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
        // Act
        _sut.ManageInputSearchStrategy(input, out var atLeastOne, out _,
            out _);
        // Assert
        Assert.True(atLeastOne.SequenceEqual(expectedAtLeastOne));
    }

    [Fact]
    public void ManageInputSearchStrategy_ShouldReturnWordsShouldBe_WhenInputIsValid()
    {
        // Arrange
        var input = new List<string> { "+test1", "test2", "-test3" };
        var expectedWordsShouldBe = new List<string> { "test2" };

        // Act
        _sut.ManageInputSearchStrategy(input, out _, out var wordsShouldBe,
            out _);

        // Assert
        Assert.True(wordsShouldBe.SequenceEqual(expectedWordsShouldBe));
    }

    [Fact]
    public void ManageInputSearchStrategy_ShouldReturnWordsShouldNotBe_WhenInputIsValid()
    {
        // Arrange
        var input = new List<string> { "+test1", "test2", "-test3" };
        var expectedWordsShouldNotBe = new List<string> { "test3" };

        // Act
        _sut.ManageInputSearchStrategy(input, out _, out _,
            out var wordsShouldNotBe);

        // Assert
        Assert.True(wordsShouldNotBe.SequenceEqual(expectedWordsShouldNotBe));
    }
}