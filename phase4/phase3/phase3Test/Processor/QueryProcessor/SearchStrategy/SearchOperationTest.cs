using System.Runtime.InteropServices.JavaScript;
using Microsoft.VisualStudio.TestPlatform.CommunicationUtilities.Resources;
using Moq;
using phase3.FileManager;
using phase3.Models;
using phase3.Processor.QueryProcessor;

namespace phase3Test.Processor.QueryProcessor.SearchStrategy;

public class SearchOperationTest
{
    private readonly SearchOperation _searchOption;
    private readonly Mock<ISearchIndexManager> _mockSearchIndexManager;
    private readonly Mock<IFileReader> _mockTextFileReader;


    public SearchOperationTest()
    {
        _mockSearchIndexManager = new Mock<ISearchIndexManager>();
        _mockTextFileReader = new Mock<IFileReader>();
        _searchOption = new SearchOperation(_mockTextFileReader.Object, _mockSearchIndexManager.Object);
    }

    [Fact]
    public void ProcessOnWord_ShouldReturnEmptyList_WhenInputContainNoWord()
    {
        // arrange
        var mockDataFiles = new List<DataFile>
        {
            new DataFile { FileName = "file1.txt", Data = "some data" }
        };

        var expectedData = new Dictionary<string, List<string>>
        {
            { "mahdi", new List<string> { "5000", "5001", "5002" } },
        };

        var expectedResult = new List<String>() { "5000", "5001", "545645" };

        _mockTextFileReader.Setup(y => y.ReadFile(It.IsAny<string>())).Returns(mockDataFiles);
        _mockSearchIndexManager.Setup(x => x.GetInvertedIndex(mockDataFiles)).Returns(expectedData);


        // act
        var resultProcessOnWords = _searchOption.SearchText("mahdi");


        // assert
        Assert.Equal(expectedResult, resultProcessOnWords);
    }
}