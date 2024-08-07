using FluentAssertions;
using phase3.InvertedIndexManager;
using phase3.Models;

namespace phase3Test.Processor.InvertedIndexManager;

public class InvertedIndexBuilderTest
{
    private readonly InvertedIndexBuilder _sut = new InvertedIndexBuilder();

    [Fact]
    public void BuildInvertedIndex_ShouldReturnCorrectDictionary_WhenGivenDataFiles()
    {
        // Arrange 
        var dataFiles = new List<DataFile>
        {
            new() { FileName = "file1.txt", Data = "apple banana orange strawberry" }
        };

        var expected = new Dictionary<string, List<string>>
        {
            { "apple", new List<string> { "file1.txt" } },
            { "banana", new List<string> { "file1.txt" } },
            { "orange", new List<string> { "file1.txt" } },
            { "strawberry", new List<string> { "file1.txt" } },
            
            { "apple banana", new List<string> { "file1.txt" } },
            { "banana orange", new List<string> { "file1.txt" } },
            { "orange strawberry", new List<string> { "file1.txt" } },
            
            { "apple banana orange", new List<string> { "file1.txt" } },
            { "banana orange strawberry", new List<string> { "file1.txt" } },
            
            { "apple banana orange strawberry", new List<string> { "file1.txt" } }

        };

        // Act
        var result = _sut.BuildInvertedIndex(dataFiles);

        // Assert
        expected.Should().BeEquivalentTo(result);
    }

    [Fact]
    public void BuildInvertedIndex_ShouldReturnNullReferenceException_WhenInputFilesIsNull()
    {
        // Arrange
        List<DataFile> dataFiles = null;

        // Act
        Action action = () => _sut.BuildInvertedIndex(dataFiles);

        // Assert
        Assert.Throws<NullReferenceException>(action);
    }
}