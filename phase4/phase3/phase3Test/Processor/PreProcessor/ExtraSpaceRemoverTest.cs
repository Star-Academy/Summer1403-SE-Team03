using phase3.Models;
using phase3.Models;
using phase3.Processor;

namespace phase3Test.ProcessorTest.PreProcessor;

public class ExtraSpaceRemoverTest
{
    [Fact]
    public void ExtraSpaceRemover_ShouldDeleteExtraSpaces_WhenInputContainsMultipleSpaces()
    {
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

        var resultExtraSpaceRemover = new ExtraSpaceRemover().Execute(testData);
        Assert.Equal(resultExtraSpaceRemover.Count , expectedTestData.Count);

        for (int i = 0; i < 2; i++)
        {
            Assert.Equal(resultExtraSpaceRemover[i].FileName,expectedTestData[i].FileName);
            Assert.Equal(resultExtraSpaceRemover[i].Data,expectedTestData[i].Data);
        }
        
    }
}