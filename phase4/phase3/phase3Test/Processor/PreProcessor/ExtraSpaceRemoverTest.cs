using phase3.Models;
using phase3.Processor;

namespace phase3Test.ProcessorTest.PreProcessor;

public class ExtraSpaceRemoverTest
{
    private readonly ExtraSpaceRemover _sut = new ExtraSpaceRemover();

    [Fact]
    public void ExtraSpaceRemover_ShouldReturnStringNotContainExtraSpace_WhenInputContainsMultipleSpaces()
    {
        // arrange
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
        
        // act
        var resultExtraSpaceRemover = _sut.Execute(testData);

        // assert
        Assert.True(expectedTestData.SequenceEqual(resultExtraSpaceRemover));
    }
}