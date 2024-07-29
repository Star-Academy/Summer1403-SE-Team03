using phase3.Models;

namespace phase3.FileManager;

public interface IFileReader
{
    List<DataFile> ReadFile(string dataPath);
}