using phase6.Models.Models;

namespace phase6.Services.IO.InputManager;

public class TextFileReader : IFileReader
{
    public List<DataFile> ReadFile(string folderPath)
    {
        var files = Directory.GetFiles(folderPath, "*");
        var data = files.Select(file => new DataFile
        {
            FileName = Path.GetFileName(file),
            Data = File.ReadAllText(file)
        }).ToList();
        return data;
    }
}