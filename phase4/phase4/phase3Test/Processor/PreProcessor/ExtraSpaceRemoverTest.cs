using phase3.Models;
using phase3.Processor;

namespace phase3Test.ProcessorTest.PreProcessor;

public class ExtraSpaceRemoverTest
{
    private readonly ExtraSpaceRemover _sut = new ExtraSpaceRemover();

    [Fact]
    public void ExtraSpaceRemover_ShouldReturnStringNotContainExtraSpace_WhenInputContainsMultipleSpaces()
    {
        // Arrange
        var testData = new List<DataFile>
        {
            new() { FileName = "file1", Data = "Te  s   t   1" },
            new() { FileName = "file2", Data = "H    iiiiii" },
            new() { FileName = "file3", Data = "" }
        };
        var expectedTestData = new List<DataFile>
        {
            new() { FileName = "file1", Data = "Te s t 1" },
            new() { FileName = "file2", Data = "H iiiiii" },
            new() { FileName = "file3", Data = "" }
        };

        // Act
        var resultExtraSpaceRemover = _sut.Execute(testData);

        // Assert
        Assert.True(expectedTestData.SequenceEqual(resultExtraSpaceRemover));
    }
    [Fact]
    public void ExtraSpaceRemover_ShouldReturnStringNotContainExtraSpace_WhenInputNotContainsMultipleSpaces()
    {
        // Arrange
        var testData = new List<DataFile>
        {
            new() { FileName = "file1", Data = "Te s t 1" },
            new() { FileName = "file2", Data = "H iiiiii" },
            new() { FileName = "file3", Data = "" }
        };
        var expectedTestData = new List<DataFile>
        {
            new() { FileName = "file1", Data = "Te s t 1" },
            new() { FileName = "file2", Data = "H iiiiii" },
            new() { FileName = "file3", Data = "" }
        };

        // Act
        var resultExtraSpaceRemover = _sut.Execute(testData);

        // Assert
        Assert.True(expectedTestData.SequenceEqual(resultExtraSpaceRemover));
    }
    [Fact]
    public void ExtraSpaceRemover_ShouldReturnNullReferenceException_WhenInputHaveNullFile()
    {
        // Arrange
        var testData = new List<DataFile>(){null};

        // Act
        Action action = () => _sut.Execute(testData);

        // Assert
        Assert.Throws<NullReferenceException>(action);
    }
    [Fact]
    public void ExtraSpaceRemover_ShouldReturnNullReferenceException_WhenInputFilesIsNull()
    {
        // Arrange
        List<DataFile> dataFiles = null;

        // Act
        Action action = () => _sut.Execute(dataFiles);

        // Assert
        Assert.Throws<NullReferenceException>(action);
    }
}
