using Moq;
using phase3.Models;
using phase3.Processor.QueryProcessor.SearchStrategy;


public class SearchStrategyFactoryTest
{
    private readonly SearchStrategyFactory _sut;
    private readonly Mock<ISearchStrategyFactory> _mockSearchStrategyFactory;

    public SearchStrategyFactoryTest()
    {
        _mockSearchStrategyFactory = new Mock<ISearchStrategyFactory>();
        _sut = new SearchStrategyFactory();
    }

    [Fact]
    public void GetValueOfKey_ShouldReturnIInputManagementObject_WhenInputIsAtLeastOneSign()
    {
        // Arrange
        var mockSearchStrategy = new Mock<IInputManagement>();
        _mockSearchStrategyFactory.Setup(x => x.GetValueOfKey(It.IsAny<string>())).Returns(mockSearchStrategy.Object);
        // Act
        var result = _sut.GetValueOfKey(QueryConstants.AtLeastOneSign);
        // Assert
        Assert.IsAssignableFrom<IInputManagement>(result);
    }

    [Fact]
    public void GetValueOfKey_ShouldReturnIInputManagementObject_WhenInputIsMustNotContainSign()
    {
        // Arrange
        var mockSearchStrategy = new Mock<IInputManagement>();
        _mockSearchStrategyFactory.Setup(x => x.GetValueOfKey(It.IsAny<string>())).Returns(mockSearchStrategy.Object);
        // Act
        var result = _sut.GetValueOfKey(QueryConstants.MustNotContainSign);
        // Assert
        Assert.IsAssignableFrom<IInputManagement>(result);
    }

    [Fact]
    public void GetValueOfKey_ShouldReturnIInputManagementObject_WhenInputIsMustContainSign()
    {
        // Arrange
        var mockSearchStrategy = new Mock<IInputManagement>();
        _mockSearchStrategyFactory.Setup(x => x.GetValueOfKey(It.IsAny<string>())).Returns(mockSearchStrategy.Object);
        // Act
        var result = _sut.GetValueOfKey(QueryConstants.MustContainSign);
        // Assert
        Assert.IsAssignableFrom<IInputManagement>(result);
    }
}