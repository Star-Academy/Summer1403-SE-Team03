using Moq;
using phase3.InvertedIndexManager;
using phase3.Models;
using phase3.Processor;

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
        // arrange
        var mockDataFiles = new List<DataFile>
        {
            new() { FileName = "file1.txt", Data = "some data" }
        };
        var expectedData = new Dictionary<string, List<string>>
        {
            { "mahdi", new List<string> { "5000", "5001" } }
        };
        _mockFileProcessor.Setup(x => x.ProcessDocumentsForIndexing(It.IsAny<List<DataFile>>())).Returns(mockDataFiles);
        _mockInvertedIndexBuilder.Setup(x => x.BuildInvertedIndex(It.IsAny<List<DataFile>>())).Returns(expectedData);

        // act
        _sut.GetInvertedIndex(new List<DataFile>());

        // assert
        Assert.Equal(expectedData, _sut.InvertedIndexDictionary);
    }
}