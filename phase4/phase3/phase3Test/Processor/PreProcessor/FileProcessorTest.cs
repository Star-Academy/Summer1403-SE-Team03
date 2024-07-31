using phase3.Models;
using phase3.Processor;

namespace phase3Test.ProcessorTest.PreProcessor;

public class FileProcessorTest
{
    private readonly FileProcessor _sut = new FileProcessor();

    [Fact]
    public void ProcessDocumentsForIndexing_ShouldApplyAllTextOperationsCorrectly()
    {
        // arrange
        var initialDataFiles = new List<DataFile>
        {
            new() { FileName = "file1.txt", Data = "  Hello, World! " },
            new() { FileName = "file2.txt", Data = "This is A Test." }
        };

        var expectedDataFiles = new List<DataFile>
        {
            new() { FileName = "file1.txt", Data = " HELLO WORLD " },
            new() { FileName = "file2.txt", Data = "THIS IS A TEST " }
        };
        
        // act        
        var result = _sut.ProcessDocumentsForIndexing(initialDataFiles);
        
        // assert
        Assert.True(expectedDataFiles.SequenceEqual(result));
    }
}