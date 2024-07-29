using phase3.Models;

namespace phase3.FileManager;

public class TextFileReader : IFileReader
{
    public List<DataFile> ReadFile(string dataPath)
    {
        return ReadFilesFromFolder(dataPath);
    }

    private List<DataFile> ReadFilesFromFolder(string folderPath)
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