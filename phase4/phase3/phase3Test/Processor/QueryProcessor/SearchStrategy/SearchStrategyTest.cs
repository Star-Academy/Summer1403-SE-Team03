using Moq;
using phase3.IO.OutPutManager;
using phase3.Models;

namespace phase3.Processor.QueryProcessor.SearchStrategy;

public class SearchStrategyTest
{
    private readonly SearchStrategy _searchStrategy;
    private readonly Mock<ISearchStrategyFactory> _mockSearchStrategyFactory;
    private readonly Mock<ISearchQueryParser> _mockSearchQueryParser;
    private readonly Mock<ISearchResultsFilter> _mockSearchResultFilter;

    public SearchStrategyTest()
    {
        _mockSearchStrategyFactory = new Mock<ISearchStrategyFactory>();
        _mockSearchQueryParser = new Mock<ISearchQueryParser>();
        _mockSearchResultFilter = new Mock<ISearchResultsFilter>();
        _searchStrategy = new SearchStrategy(_mockSearchStrategyFactory.Object, _mockSearchQueryParser.Object,
            _mockSearchResultFilter.Object);
    }

    [Fact]
    public void ProcessOnWord_ShouldReturnEmptyList_WhenInputContainNoWord()
    {
        // arrange
        var input = new List<string> { "+test1", "test2", "-test3" };
        List<string> atLeastOne = new();
        List<string> wordsShouldBe = new();
        List<string> wordsShouldNotBe = new();
        _mockSearchQueryParser.Verify(x =>
            x.ManageInputSearchStrategy(It.IsAny<List<string>>(),out atLeastOne, out wordsShouldBe, out wordsShouldNotBe),Times.Once);
        _mockSearchStrategyFactory.Verify(x =>x.GetValueOfKey(QueryConstants.MustContainSign).ProcessOnWords(wordsShouldBe) , Times.Never);
        _mockSearchStrategyFactory.Verify(x =>x.GetValueOfKey(QueryConstants.MustNotContainSign).ProcessOnWords(wordsShouldNotBe) , Times.Never);
        _mockSearchStrategyFactory.Verify(x =>x.GetValueOfKey(QueryConstants.AtLeastOneSign).ProcessOnWords(atLeastOne) , Times.Never);
        
        _mockSearchResultFilter.Verify(x => x.GetResult(atLeastOne , wordsShouldBe , wordsShouldNotBe) , Times.Never);
        
        // act
        var result = _searchStrategy.ManageSearchStrategy("+test1 test2 -test3");
        
        // assert
        Assert.IsAssignableFrom<IEnumerable<string>>(result);
    }
}