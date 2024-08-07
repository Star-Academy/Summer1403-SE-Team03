using phase6.Models.Models;

namespace phase6.Services.IO.InputManager;

public interface IFileReader
{
    List<DataFile> ReadFile(string dataPath);
}