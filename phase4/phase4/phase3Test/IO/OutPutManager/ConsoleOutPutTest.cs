using Moq;
using phase3.IO.OutPutManager;
using phase3.Processor.QueryProcessor.SearchStrategy;

namespace phase3Test.IO.OutPutManager;

public class ConsoleOutPutTest
{
    private readonly ConsoleOutput _sut;
    private readonly Mock<ISearchStrategy> _mockSearchStrategy;

    public ConsoleOutPutTest()
    {
        _mockSearchStrategy = new Mock<ISearchStrategy>();
        _sut = new ConsoleOutput(_mockSearchStrategy.Object);
    }

    [Fact]
    public void OutputProcess_ShouldReturnUniqueResult_WhenInputContainWordAndResultIsNotEmpty()
    {
        // Arrange
        _mockSearchStrategy.Setup(x => x.ManageSearchStrategy(It.IsAny<string>()))
            .Returns(new List<string> { "test1" });

        // Act
        var result = _sut.OutputProcess("mahdi");

        // Assert
        Assert.IsType<List<string>>(result);
    }

    [Fact]
    public void OutputProcess_ShouldReturnEmptyList_WhenInputContainWordAndResultIsEmpty()
    {
        // Arrange
        _mockSearchStrategy.Setup(x => x.ManageSearchStrategy(It.IsAny<string>())).Returns(new List<string> { });

        // Act
        var result = _sut.OutputProcess("mahdi");

        // Assert
        Assert.IsType<List<string>>(result);
    }
}