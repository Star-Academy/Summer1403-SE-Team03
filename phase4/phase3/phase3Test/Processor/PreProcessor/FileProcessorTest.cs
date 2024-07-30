using phase3.Models;
using phase3.Processor;

namespace phase3Test.ProcessorTest.PreProcessor;

public class FileProcessorTest
{
    [Fact]
    public void ProcessDocumentsForIndexing_ShouldApplyAllTextOperationsCorrectly()
    {
        // arrange
        var initialDataFiles = new List<DataFile>
        {
            new DataFile { FileName = "file1.txt", Data = "  Hello, World! " },
            new DataFile { FileName = "file2.txt", Data = "This is A Test." }
        };

        var expectedDataFiles = new List<DataFile>
        {
            new DataFile { FileName = "file1.txt", Data = "hello world" },
            new DataFile { FileName = "file2.txt", Data = "this is a test" }
        };

        var fileProcessor = new FileProcessor();

        // act        
        var result = fileProcessor.ProcessDocumentsForIndexing(initialDataFiles);
        // assert
        for (int i = 0; i < expectedDataFiles.Count; i++)
        {
            Assert.Equal(expectedDataFiles[i].Data, result[i].Data);
        }
    }
}