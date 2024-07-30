using Moq;
using phase3.Processor.QueryProcessor.SearchStrategy;
using phase3.Processor.QueryProcessor.SearchStrategy.SearchStrategyImplemention;

namespace phase3Test.Processor.QueryProcessor.SearchImplemention;

public class MustIncludeWordTest
{
    
    private readonly MustIncludeWord _containOneOfWordSearch;
    private readonly Mock<ISearchOperation> _mockContainOneOfWordSearch;

    public MustIncludeWordTest()
    {
        _mockContainOneOfWordSearch = new Mock<ISearchOperation>();
        _containOneOfWordSearch = new MustIncludeWord(_mockContainOneOfWordSearch.Object);
    }

    [Fact]
    public void ProcessOnWord_ShouldReturnUniqueResult_WhenInputContainNoWord()
    {
        // arrange
        var inputData = new List<string> {};
        var expectedData = new Dictionary<string, List<string>>
        {
            { "mahdi", new List<string> { "5000", "5001","5002" } },
            { "mahshad", new List<string> { "5000", "5001","5003"} },
        };
        var result = new List<string> { };

        _mockContainOneOfWordSearch.Setup(x => x.SearchText("mahshad")).Returns(expectedData["mahshad"]);
        _mockContainOneOfWordSearch.Setup(x => x.SearchText("mahdi")).Returns(expectedData["mahdi"]);
        // act
        var resultProcessOnWords = _containOneOfWordSearch.ProcessOnWords(inputData);
        
        // assert
        Assert.Equal(result , resultProcessOnWords);
    }
    
}