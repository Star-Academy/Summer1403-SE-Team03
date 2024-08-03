using Moq;
using phase3.IO.OutPutManager;
using phase3.Models;

namespace phase3.Processor.QueryProcessor.SearchStrategy;

public class SearchStrategyTest
{
    private readonly SearchStrategy _sut;
    private readonly Mock<ISearchStrategyFactory> _mockSearchStrategyFactory;
    private readonly Mock<ISearchQueryParser> _mockSearchQueryParser;
    private readonly Mock<ISearchResultsFilter> _mockSearchResultFilter;

    public SearchStrategyTest()
    {
        _mockSearchStrategyFactory = new Mock<ISearchStrategyFactory>();
        _mockSearchQueryParser = new Mock<ISearchQueryParser>();
        _mockSearchResultFilter = new Mock<ISearchResultsFilter>();
        _sut = new SearchStrategy(_mockSearchStrategyFactory.Object, _mockSearchQueryParser.Object,
            _mockSearchResultFilter.Object);
    }

    [Fact]
    public void ProcessOnWord_ShouldReturnEmptyList_WhenInputContainNoWord()
    {
        // Arrange
        List<string> atLeastOne = new();
        List<string> wordsShouldBe = new();
        List<string> wordsShouldNotBe = new();
        var expectedData = new List<string>();
        
        _mockSearchQueryParser
            .Setup(x => x.ManageInputSearchStrategy(new List<string>(), out It.Ref<List<string>>.IsAny,
                out It.Ref<List<string>>.IsAny,
                out It.Ref<List<string>>.IsAny)).Callback(
                (IReadOnlyList<string> input, out List<string> atLeastOne, out List<string> wordsShouldBe,
                    out List<string> wordsShouldNotBe) =>
                {
                    atLeastOne = new List<string>() { "5000", "5002" };
                    wordsShouldBe = new List<string>() { "5002", "5003" };
                    wordsShouldNotBe = new List<string>() { "5004", "5003" };
                });

        _mockSearchStrategyFactory.Setup(x =>
                x.GetValueOfKey(QueryConstants.AtLeastOneSign).ProcessOnWords(atLeastOne))
            .Returns(new List<string>() { "result 1" });
        _mockSearchStrategyFactory.Setup(x =>
                x.GetValueOfKey(QueryConstants.MustContainSign).ProcessOnWords(wordsShouldBe))
            .Returns(new List<string>() { "result 2" });
        _mockSearchStrategyFactory.Setup(x =>
                x.GetValueOfKey(QueryConstants.MustNotContainSign).ProcessOnWords(wordsShouldNotBe))
            .Returns(new List<string>() { "result 3" });

        _mockSearchResultFilter
            .Setup(x => x.GetResult(It.Ref<List<string>>.IsAny, It.Ref<List<string>>.IsAny, It.Ref<List<string>>.IsAny))
            .Returns(new List<string>(){});

        // Act
        var result = _sut.ManageSearchStrategy("+test1 test2 -test3");
        
        // Assert
        Assert.Equal(expectedData,result);
    }
}