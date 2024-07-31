using Moq;
using phase3.Processor.QueryProcessor.SearchStrategy;

namespace phase3Test.Processor.QueryProcessor.SearchImplemention;

public class MustIncludeWordTest
{
    private readonly MustIncludeWord _sut;
    private readonly Mock<ISearchOperation> _mockMustIncludeWordSearch;

    public MustIncludeWordTest()
    {
        _mockMustIncludeWordSearch = new Mock<ISearchOperation>();
        _sut = new MustIncludeWord(_mockMustIncludeWordSearch.Object);
    }

    [Fact]
    public void ProcessOnWord_ShouldReturnUniqueResult_WhenInputContainWord()
    {
        // arrange
        var inputData = new List<string> { "mahdi", "mahshad" };
        var expectedData = new Dictionary<string, List<string>>
        {
            { "mahdi", new List<string> { "5000", "5001", "5002" } },
            { "mahshad", new List<string> { "5000", "5001", "5003" } }
        };
        var result = new List<string> { "5000", "5001" };

        _mockMustIncludeWordSearch.Setup(x => x.SearchText("mahshad")).Returns(expectedData["mahshad"]);
        _mockMustIncludeWordSearch.Setup(x => x.SearchText("mahdi")).Returns(expectedData["mahdi"]);
        
        // act
        var resultProcessOnWords = _sut.ProcessOnWords(inputData);

        // assert
        Assert.Equal(result, resultProcessOnWords);
    }
}