using phase3.Models;
using phase3.Processor;

namespace phase3Test.ProcessorTest.PreProcessor;

public class UpperCaseMakerTest
{
    [Fact]
    public void UpperCaseMaker_ShouldMakeUpperInput_WhenInputHaveLowerChar()
    {
        // arrange
        var testData = new List<DataFile>
        {
            new DataFile { FileName = "file1", Data = "salaammm khubiiii manam khuuuuuuubam" },
            new DataFile { FileName = "file2", Data = "Hiiiiii" }
        };
        var expectedTestData = new List<DataFile>
        {
            new DataFile { FileName = "file1", Data = "SALAAMMM KHUBIIII MANAM KHUUUUUUUBAM" },
            new DataFile { FileName = "file2", Data = "HIIIIII" }
        };
        // act
        var resultUpperMaker = new UpperCaseMaker().Execute(testData);
        // assert
        for (int i = 0; i < 2; i++)
        {
            Assert.Equal(expectedTestData[i].Data, resultUpperMaker[i].Data);
        }
    }
}