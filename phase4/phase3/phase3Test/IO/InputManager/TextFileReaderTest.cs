using phase3.FileManager;

namespace phase3Test.IO.InputManager;

public class TextFileReaderTest
{
    private string _testDirectory;
    private TextFileReader _sut;

    public TextFileReaderTest()
    {
        _testDirectory = Path.Combine(Path.GetTempPath(), Guid.NewGuid().ToString());
        Directory.CreateDirectory(_testDirectory);
        _sut = new TextFileReader();
    }

    public void Dispose()
    {
        Directory.Delete(_testDirectory, true);
    }

    [Fact]
    public void ReadFile_ShouldReturnDataFiles_WhenInputIsAddressOfDirectory()
    {
        // arrange 
        var file1Path = Path.Combine(_testDirectory, "file1.txt");

        File.WriteAllText(file1Path, "This is the content of file1.");
        // act
        var result = _sut.ReadFile(_testDirectory);
        // assert
        Assert.Contains(result, f => f.FileName == "file1.txt" && f.Data == "This is the content of file1.");
    }

    [Fact]
    public void ReadFile_ShouldReturnEmptyList_WhenInputDirectoryDoseNotHaveAnyFile()
    {
        // act
        var result = _sut.ReadFile(_testDirectory);
        // arrange
        Assert.Empty(result);
    }

    [Fact]
    public void ReadFile_ShouldThrowDirectoryNotFoundException_WhenDirectoryNotFound()
    {
        // arrange
        var nonExistentDirectory = Path.Combine(Path.GetTempPath(), Guid.NewGuid().ToString());
        // act
        Action action = () => _sut.ReadFile(nonExistentDirectory);
        // assert 
        Assert.Throws<DirectoryNotFoundException>(action);
    }
}