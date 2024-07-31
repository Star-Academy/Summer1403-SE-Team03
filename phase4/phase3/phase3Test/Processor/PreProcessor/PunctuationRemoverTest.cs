using phase3.Models;
using phase3.Processor;

namespace phase3Test.ProcessorTest.PreProcessor;

public class PunctuationRemoverTest
{
    [Fact]
    public void PunctuationRemover_ShouldDeletePunctuation_WhenInputContainsPunctuation()
    {
        // arrange
        var testData = new List<DataFile>
        {
            new DataFile { FileName = "file1", Data = "This is @test- one" },
            new DataFile { FileName = "file2", Data = "this *is test### two" }
        };
        var expectedTestData = new List<DataFile>
        {
            new DataFile { FileName = "file1", Data = "This is  test  one" },
            new DataFile { FileName = "file2", Data = "this  is test    two" }
        };
        // act        
        var resultPunctuationRemover = new PunctuationRemover().Execute(testData);
        // assert
        for (int i = 0; i < 2; i++)
        {
            Assert.Equal(expectedTestData[i].Data, resultPunctuationRemover[i].Data);
        }
    }
}