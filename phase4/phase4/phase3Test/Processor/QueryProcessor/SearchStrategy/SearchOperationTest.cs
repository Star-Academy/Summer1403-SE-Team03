using Moq;
using phase3.FileManager;
using phase3.Models;
using phase3.Processor.QueryProcessor;

namespace phase3Test.Processor.QueryProcessor.SearchStrategy;

public class SearchOperationTest
{
    private readonly SearchOperation _sut;
    private readonly Mock<ISearchIndexManager> _mockSearchIndexManager;
    private readonly Mock<IFileReader> _mockTextFileReader;


    public SearchOperationTest()
    {
        _mockSearchIndexManager = new Mock<ISearchIndexManager>();
        _mockTextFileReader = new Mock<IFileReader>();
        _sut = new SearchOperation(_mockTextFileReader.Object, _mockSearchIndexManager.Object);
    }

    [Fact]
    public void SearchText_ShouldReturnInvertedIndexDictionary_WhenInputContainWord()
    {
        // Arrange
        var mockDataFiles = new List<DataFile>
        {
            new() { FileName = "file1.txt", Data = "some data" }
        };

        var data = new Dictionary<string, List<string>>
        {
            { "mahdi", new List<string> { "5000", "5001", "5002" } }
        };

        var expectedResult = new List<string>() { "5000", "5001", "5002" };

        _mockTextFileReader.Setup(y => y.ReadFile(It.IsAny<string>())).Returns(mockDataFiles);
        _mockSearchIndexManager.Setup(x => x.GetInvertedIndex(mockDataFiles)).Returns(data);


        // Act
        var resultProcessOnWords = _sut.SearchText("mahdi");


        // Assert
        Assert.Equal(expectedResult, resultProcessOnWords);
    }

    [Fact]
    public void SearchText_ShouldReturnEmptyList_WhenDocumentsAreNull()
    {
        // Arrange
        _mockTextFileReader.Setup(x => x.ReadFile(It.IsAny<string>())).Returns(new List<DataFile>());
        _mockSearchIndexManager.Setup(x => x.GetInvertedIndex(It.IsAny<List<DataFile>>()))
            .Returns(new Dictionary<string, List<string>>());

        // Act
        var result = _sut.SearchText("nonexistent");

        // Assert
        Assert.Empty(result);
    }
}