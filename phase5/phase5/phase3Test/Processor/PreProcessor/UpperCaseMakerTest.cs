using phase3.Models;
using phase3.Processor;

namespace phase3Test.ProcessorTest.PreProcessor;

public class UpperCaseMakerTest
{
    private readonly UpperCaseMaker _sut = new UpperCaseMaker();

    [Fact]
    public void UpperCaseMaker_ShouldMakeUpperInput_WhenInputHaveLowerChar()
    {
        // Arrange
        var testData = new List<DataFile>
        {
            new() { FileName = "file1", Data = "tesT1 is HerE" },
            new() { FileName = "file2", Data = "Hiiiiii" }
        };
        var expectedTestData = new List<DataFile>
        {
            new() { FileName = "file1", Data = "TEST1 IS HERE" },
            new() { FileName = "file2", Data = "HIIIIII" }
        };

        // Act
        var resultUpperMaker = _sut.Execute(testData);

        // Assert
        Assert.True(expectedTestData.SequenceEqual(resultUpperMaker));
    }
}