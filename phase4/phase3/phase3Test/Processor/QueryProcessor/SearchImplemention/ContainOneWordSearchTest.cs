using Moq;
using phase3.Processor.QueryProcessor.SearchStrategy;

namespace phase3Test.Processor.QueryProcessor.SearchImplemention;

public class ContainOneWordSearchTest
{
    private readonly ContainOneOfWordSearch _sut;
    private readonly Mock<ISearchOperation> _mockContainOneOfWordSearch;

    public ContainOneWordSearchTest()
    {
        _mockContainOneOfWordSearch = new Mock<ISearchOperation>();
        _sut = new ContainOneOfWordSearch(_mockContainOneOfWordSearch.Object);
    }

    [Fact]
    public void ProcessOnWord_ShouldReturnUniqueResult_WhenInputContainAnyWordOfList()
    {
        // arrange
        var inputData = new List<string> { "mahdi", "mahshad" };
        var expectedData = new Dictionary<string, List<string>>
        {
            { "mahdi", new List<string> { "5000", "5001", "5002" } },
            { "mahshad", new List<string> { "5000", "5001" } }
        };
        var result = new List<string> { "5000", "5001", "5002" };

        _mockContainOneOfWordSearch.Setup(x => x.SearchText("mahshad")).Returns(expectedData["mahshad"]);
        _mockContainOneOfWordSearch.Setup(x => x.SearchText("mahdi")).Returns(expectedData["mahdi"]);
        // act
        var resultProcessOnWords = _sut.ProcessOnWords(inputData);

        // assert
        Assert.Equal(result, resultProcessOnWords);
    }

    [Fact]
    public void ProcessOnWord_ShouldReturnUniqueResult_WhenInputContainDuplicateList()
    {
        // arrange
        var inputData = new List<string> { "mahdi", "mahshad" };
        var expectedData = new Dictionary<string, List<string>>
        {
            { "mahdi", new List<string> { "5000", "5001" } },
            { "mahshad", new List<string> { "5000", "5001" } }
        };
        var result = new List<string> { "5000", "5001" };

        _mockContainOneOfWordSearch.Setup(x => x.SearchText("mahshad")).Returns(expectedData["mahshad"]);
        _mockContainOneOfWordSearch.Setup(x => x.SearchText("mahdi")).Returns(expectedData["mahdi"]);
        // act
        var resultProcessOnWords = _sut.ProcessOnWords(inputData);

        // assert
        Assert.Equal(result, resultProcessOnWords);
    }

    [Fact]
    public void ProcessOnWord_ShouldReturnEmptyList_WhenInputContainNoWord()
    {
        // arrange
        var inputData = new List<string> { };
        var expectedData = new Dictionary<string, List<string>>
        {
            { "mahdi", new List<string> { "5000", "5001" } },
            { "mahshad", new List<string> { "5000", "5001" } }
        };
        var result = new List<string> { };

        _mockContainOneOfWordSearch.Setup(x => x.SearchText("mahshad")).Returns(expectedData["mahshad"]);
        _mockContainOneOfWordSearch.Setup(x => x.SearchText("mahdi")).Returns(expectedData["mahdi"]);
        // act
        var resultProcessOnWords = _sut.ProcessOnWords(inputData);

        // assert
        Assert.Equal(result, resultProcessOnWords);
    }
}