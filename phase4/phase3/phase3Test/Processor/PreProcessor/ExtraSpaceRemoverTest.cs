using phase3.Models;
using phase3.Models;
using phase3.Processor;

namespace phase3Test.ProcessorTest.PreProcessor;

public class ExtraSpaceRemoverTest
{
    [Fact]
    public void ExtraSpaceRemover_ShouldDeleteExtraSpaces_WhenInputContainsMultipleSpaces()
    {
        // arrange
        var testData = new List<DataFile>
        {
            new DataFile { FileName = "file1", Data = "sa  laa mmm khu   biiii  manam khuuuuuuu            bam" },
            new DataFile { FileName = "file2", Data = "H    iiiiii" }
        };
        var expectedTestData = new List<DataFile>
        {
            new DataFile { FileName = "file1", Data = "sa laa mmm khu biiii manam khuuuuuuu bam" },
            new DataFile { FileName = "file2", Data = "H iiiiii" }
        };
        // act
        var resultExtraSpaceRemover = new ExtraSpaceRemover().Execute(testData);

        // assert
        for (int i = 0; i < 2; i++)
        {
            Assert.Equal(expectedTestData[i].Data,resultExtraSpaceRemover[i].Data);
        }
        
    }
}