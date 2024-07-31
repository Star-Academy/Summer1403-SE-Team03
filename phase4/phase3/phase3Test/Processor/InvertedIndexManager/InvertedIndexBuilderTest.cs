using phase3.InvertedIndexManager;
using phase3.Models;

namespace phase3Test.Processor.InvertedIndexManager;

public class InvertedIndexBuilderTest
{
    [Fact]
    public void BuildInvertedIndex_ShouldReturnCorrectDictionary_WhenGivenListOfDataFiles()
    {
        var dataFiles = new List<DataFile>
        {
            new DataFile { FileName = "file1.txt", Data = "apple banana apple" },
            new DataFile { FileName = "file2.txt", Data = "banana orange banana" }
        };

        var expected = new Dictionary<string, List<string>>
        {
            { "apple", new List<string> { "file1.txt" } },
            { "banana", new List<string> { "file1.txt", "file2.txt" } },
            { "orange", new List<string> { "file2.txt" } }
        };

        var indexBuilder = new InvertedIndexBuilder();

        var result = indexBuilder.BuildInvertedIndex(dataFiles);

        Assert.Equal(expected.Count, result.Count);

        foreach (var element in expected)
        {
            Assert.True(result.ContainsKey(element.Key));
            Assert.Equal(element.Value, result[element.Key]);
        }
    }
}