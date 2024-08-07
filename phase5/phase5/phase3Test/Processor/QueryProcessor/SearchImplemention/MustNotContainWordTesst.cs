using Moq;
using phase3.Processor.QueryProcessor.SearchStrategy;

namespace phase3Test.Processor.QueryProcessor.SearchImplemention;

public class MustNotContainWordTest
{
    private readonly MustNotContainWord _sut;
    private readonly Mock<ISearchOperation> _mockMustNotContainWordSearch;

    public MustNotContainWordTest()
    {
        _mockMustNotContainWordSearch = new Mock<ISearchOperation>();
        _sut = new MustNotContainWord(_mockMustNotContainWordSearch.Object);
    }

    [Fact]
    public void ProcessOnWord_ShouldReturnUniqueResult_WhenInputContainWordOfList()
    {
        // Arrange
        var inputData = new List<string> { "mahdi", "mahshad" };
        var expectedData = new Dictionary<string, List<string>>
        {
            { "mahdi", new List<string> { "5000", "5001", "5002" } },
            { "mahshad", new List<string> { "5000", "5001" } }
        };
        var expected = new List<string> { "5000", "5001", "5002" };

        _mockMustNotContainWordSearch.Setup(x => x.SearchText("mahshad")).Returns(expectedData["mahshad"]);
        _mockMustNotContainWordSearch.Setup(x => x.SearchText("mahdi")).Returns(expectedData["mahdi"]);

        // Act
        var resultProcessOnWords = _sut.ProcessOnWords(inputData);

        // Assert
        Assert.Equivalent(expected, resultProcessOnWords);
    }

    [Fact]
    public void ProcessOnWord_ShouldReturnUniqueResult_WhenInputContainDuplicateList()
    {
        // Arrange
        var inputData = new List<string> { "mahdi", "mahshad" };
        var expectedData = new Dictionary<string, List<string>>
        {
            { "mahdi", new List<string> { "5000", "5001" } },
            { "mahshad", new List<string> { "5000", "5001" } }
        };
        var expected = new List<string> { "5000", "5001" };

        _mockMustNotContainWordSearch.Setup(x => x.SearchText("mahshad")).Returns(expectedData["mahshad"]);
        _mockMustNotContainWordSearch.Setup(x => x.SearchText("mahdi")).Returns(expectedData["mahdi"]);

        // Act
        var resultProcessOnWords = _sut.ProcessOnWords(inputData);

        // Assert
        Assert.Equivalent(expected, resultProcessOnWords);
    }

    [Fact]
    public void ProcessOnWord_ShouldReturnUniqueResult_WhenInputContainNoWord()
    {
        // Arrange
        var inputData = new List<string> { };
        var expectedData = new Dictionary<string, List<string>>
        {
            { "mahdi", new List<string> { "5000", "5001" } },
            { "mahshad", new List<string> { "5000", "5001" } }
        };
        var expected = new List<string> { };

        _mockMustNotContainWordSearch.Setup(x => x.SearchText("mahshad")).Returns(expectedData["mahshad"]);
        _mockMustNotContainWordSearch.Setup(x => x.SearchText("mahdi")).Returns(expectedData["mahdi"]);

        // Act
        var resultProcessOnWords = _sut.ProcessOnWords(inputData);

        // Assert
        Assert.Equivalent(expected, resultProcessOnWords);
    }
}