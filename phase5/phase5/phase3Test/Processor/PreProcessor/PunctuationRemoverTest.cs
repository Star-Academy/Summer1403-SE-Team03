using phase3.Models;
using phase3.Processor;

namespace phase3Test.ProcessorTest.PreProcessor;

public class PunctuationRemoverTest
{
    private readonly PunctuationRemover _sut = new PunctuationRemover();

    [Fact]
    public void PunctuationRemover_ShouldDeletePunctuation_WhenInputContainsPunctuation()
    {
        // Arrange
        var testData = new List<DataFile>
        {
            new() { FileName = "file1", Data = "This is @test- one" },
            new() { FileName = "file2", Data = "this *is test### two" }
        };
        var expectedTestData = new List<DataFile>
        {
            new() { FileName = "file1", Data = "This is  test  one" },
            new() { FileName = "file2", Data = "this  is test    two" }
        };

        // Act        
        var resultPunctuationRemover = _sut.Execute(testData);

        // Assert
        Assert.True(expectedTestData.SequenceEqual(resultPunctuationRemover));
    }
}