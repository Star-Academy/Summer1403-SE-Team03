using Moq;
using phase3.Processor.QueryProcessor.SearchStrategy;
using phase3.Processor.QueryProcessor.SearchStrategy.IFilterStrategy;
using phase3.Processor.QueryProcessor.SearchStrategy.SearchStrategyImplemention;

namespace phase3Test.Processor.QueryProcessor.SearchStrategy;

public class SearchQueryParserTest
{
    private readonly Mock<IAtLeastOneInputStrategy> _mockAtLeastOneInputStrategy;
    private readonly Mock<IMustIncludeInputStrategy> _mockMustIncludeInputStrategy;
    private readonly Mock<IMustNotContainInputStrategy> _mockMustNotContainInputStrategy;
    private readonly SearchQueryParser _sut;

    public SearchQueryParserTest()
    {
        _mockAtLeastOneInputStrategy = new Mock<IAtLeastOneInputStrategy>();
        _mockMustIncludeInputStrategy = new Mock<IMustIncludeInputStrategy>();
        _mockMustNotContainInputStrategy = new Mock<IMustNotContainInputStrategy>();
        _sut = new SearchQueryParser(_mockAtLeastOneInputStrategy.Object, _mockMustIncludeInputStrategy.Object,
            _mockMustNotContainInputStrategy.Object);
    }

    [Fact]
    public void ManageInputSearchStrategy_ShouldReturnFilterListStrategies_WhenInputIsValid()
    {
        // Arrange
        var input = new List<string> { "+test1", "test2", "-test3" };
        var expectedAtLeastOne = new List<string> { "test1" };
        _mockAtLeastOneInputStrategy.Setup(x => x.Apply(It.IsAny<IReadOnlyList<string>>()))
            .Returns(new List<string>() { "test1" });
        _mockMustIncludeInputStrategy.Setup(x => x.Apply(It.IsAny<IReadOnlyList<string>>()))
            .Returns(new List<string>() { });
        _mockMustNotContainInputStrategy.Setup(x => x.Apply(It.IsAny<IReadOnlyList<string>>()))
            .Returns(new List<string>() { });


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
        _mockAtLeastOneInputStrategy.Setup(x => x.Apply(It.IsAny<IReadOnlyList<string>>()))
            .Returns(new List<string>() { });
        _mockMustIncludeInputStrategy.Setup(x => x.Apply(It.IsAny<IReadOnlyList<string>>()))
            .Returns(new List<string>() { "test2" });
        _mockMustNotContainInputStrategy.Setup(x => x.Apply(It.IsAny<IReadOnlyList<string>>()))
            .Returns(new List<string>() { });


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
        _mockAtLeastOneInputStrategy.Setup(x => x.Apply(It.IsAny<IReadOnlyList<string>>()))
            .Returns(new List<string>() { });
        _mockMustIncludeInputStrategy.Setup(x => x.Apply(It.IsAny<IReadOnlyList<string>>()))
            .Returns(new List<string>() { });
        _mockMustNotContainInputStrategy.Setup(x => x.Apply(It.IsAny<IReadOnlyList<string>>()))
            .Returns(new List<string>() { "test3" });


        // Act
        _sut.ManageInputSearchStrategy(input, out _, out _,
            out var wordsShouldNotBe);

        // Assert
        Assert.True(wordsShouldNotBe.SequenceEqual(expectedWordsShouldNotBe));
    }
}