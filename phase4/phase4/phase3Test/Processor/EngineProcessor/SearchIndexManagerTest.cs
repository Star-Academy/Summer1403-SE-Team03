using Moq;
using phase3.InvertedIndexManager;
using phase3.Models;
using phase3.Processor;
using phase3.Processor.FileProcessorFactory;

namespace phase3Test.Processor.EngineProcessor;

public class SearchIndexManagerTest
{
    private readonly SearchIndexManager _sut;
    private readonly Mock<IFileProcessor> _mockFileProcessor;
    private readonly Mock<IInvertedIndexBuilder> _mockInvertedIndexBuilder;


    public SearchIndexManagerTest()
    {
        _mockFileProcessor = new Mock<IFileProcessor>();
        _mockInvertedIndexBuilder = new Mock<IInvertedIndexBuilder>();
        _sut = new SearchIndexManager(_mockFileProcessor.Object, _mockInvertedIndexBuilder.Object);
    }

    [Fact]
    public void GetInvertedIndex_ShouldSetDictionary_WhenInputContainDataFileList()
    {
        // Arrange
        var mockDataFiles = new List<DataFile>
        {
            new() { FileName = "file1.txt", Data = "some data" }
        };
        var expectedData = new Dictionary<string, List<string>>
        {
            { "mahdi", new List<string> { "5000", "5001" } }
        };
        _mockFileProcessor.Setup(x => x.ProcessDocumentsForIndexing(It.IsAny<List<DataFile>>() ,new ProcessFactory())).Returns(mockDataFiles);
        _mockInvertedIndexBuilder.Setup(x => x.BuildInvertedIndex(It.IsAny<List<DataFile>>())).Returns(expectedData);

        // Act
        _sut.GetInvertedIndex(new List<DataFile>());

        // Assert
        Assert.Equal(expectedData, _sut.InvertedIndexDictionary);
    }

    [Fact]
    public void GetInvertedIndex_ShouldThrowArgumentNullException_WhenFileProcessorIsNull()
    {
        // Act
        var exception = Record.Exception(() => new SearchIndexManager(null, _mockInvertedIndexBuilder.Object));

        // Assert
        Assert.IsType<ArgumentNullException>(exception);
    }

    [Fact]
    public void GetInvertedIndex_ShouldThrowArgumentNullException_WhenInvertedIndexBuilderIsNull()
    {
        // Act
        var exception = Record.Exception(() => new SearchIndexManager(_mockFileProcessor.Object, null));

        // Assert
        Assert.IsType<ArgumentNullException>(exception);
    }
}