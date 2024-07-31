using phase3.Models;
using phase3.Processor;

namespace phase3Test.ProcessorTest.PreProcessor;

public class UpperCaseMakerTest
{
    private readonly UpperCaseMaker _sut = new UpperCaseMaker();

    [Fact]
    public void UpperCaseMaker_ShouldMakeUpperInput_WhenInputHaveLowerChar()
    {
        // arrange
        var testData = new List<DataFile>
        {
            new() { FileName = "file1", Data = "salaammm khubiiii manam khuuuuuuubam" },
            new() { FileName = "file2", Data = "Hiiiiii" }
        };
        var expectedTestData = new List<DataFile>
        {
            new() { FileName = "file1", Data = "SALAAMMM KHUBIIII MANAM KHUUUUUUUBAM" },
            new() { FileName = "file2", Data = "HIIIIII" }
        };
        // act
        var resultUpperMaker = _sut.Execute(testData);
        // assert
        Assert.True(expectedTestData.SequenceEqual(resultUpperMaker));
    }
}