using Moq;
using phase3.IO.OutPutManager;
using phase3.Processor.QueryProcessor.SearchStrategy;

namespace phase3Test.IO.OutPutManager;

public class ConsoleOutPutTest
{
    private readonly ConsoleOutput _sut;
    private readonly Mock<ISearchStrategy> _maockSearchStrategy;

    public ConsoleOutPutTest()
    {
        _maockSearchStrategy = new Mock<ISearchStrategy>();
        _sut = new ConsoleOutput(_maockSearchStrategy.Object);
    }

    [Fact]
    public void OutputProcess_ShouldReturnUniqueResult_WhenInputContainWordAndResultIsNotEmpty()
    {
        // arrange
        _maockSearchStrategy.Setup(x => x.ManageSearchStrategy(It.IsAny<string>()))
            .Returns(new List<string> { "test1" });
        // act
        var result = _sut.OutputProcess("mahdi");
        // assert
        Assert.IsType<List<string>>(result);
    }

    [Fact]
    public void OutputProcess_ShouldReturnEmptyList_WhenInputContainWordAndResultIsEmpty()
    {
        // arrange
        _maockSearchStrategy.Setup(x => x.ManageSearchStrategy(It.IsAny<string>())).Returns(new List<string> { });
        // act
        var result = _sut.OutputProcess("mahdi");
        // assert
        Assert.IsType<List<string>>(result);
    }
}