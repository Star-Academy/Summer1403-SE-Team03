using phase3.Models;

namespace phase3.FileManager;

public class FileReader
{

    private static readonly FileReader _fileReader = new FileReader();

    public static FileReader Instance
    {
        get
        {
            return _fileReader;
        }
    }
    public List<DataFile> ReadFiles()
    {
        return ReadFilesFromFolder(ReadFolderPath());
    }

    private string ReadFolderPath()
    {
        return Resources.databasePath;
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