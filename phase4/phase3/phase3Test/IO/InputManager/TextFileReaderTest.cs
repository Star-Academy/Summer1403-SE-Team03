using phase3.FileManager;

namespace phase3Test.IO.InputManager;

public class TextFileReaderTest
{
    private readonly string _testDirectory;
    private readonly TextFileReader _sut;

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
        // Arrange 
        var file1Path = Path.Combine(_testDirectory, "file1.txt");
        File.WriteAllText(file1Path, "This is the content of file1.");

        // Act
        var result = _sut.ReadFile(_testDirectory);

        // Assert
        Assert.Contains(result, f => f.FileName == "file1.txt" && f.Data == "This is the content of file1.");
    }

    [Fact]
    public void ReadFile_ShouldReturnEmptyList_WhenInputDirectoryDoseNotHaveAnyFile()
    {
        // Act
        var result = _sut.ReadFile(_testDirectory);

        // Arrange
        Assert.Empty(result);
    }

    [Fact]
    public void ReadFile_ShouldThrowDirectoryNotFoundException_WhenDirectoryNotFound()
    {
        // Arrange
        var nonExistentDirectory = Path.Combine(Path.GetTempPath(), Guid.NewGuid().ToString());

        // Act
        Action action = () => _sut.ReadFile(nonExistentDirectory);

        // Assert 
        Assert.Throws<DirectoryNotFoundException>(action);
    }
}