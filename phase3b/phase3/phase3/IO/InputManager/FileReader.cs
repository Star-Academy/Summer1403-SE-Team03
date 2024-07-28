using phase3.Models;

namespace phase3.FileManager;

public class FileReader : IFileReader
{
    public List<DataFile> ReadFile(string dataPath)
    {
        return ReadFilesFromFolder(dataPath);
    }

    private List<DataFile> ReadFilesFromFolder(string folderPath)
    {
        List<DataFile> data = new();
        var files = Directory.GetFiles(folderPath, "*");
        foreach (var file in files)
            data.Add(new DataFile { FileName = Path.GetFileName(file), Data = File.ReadAllText(file) });
        return data;
    }
}