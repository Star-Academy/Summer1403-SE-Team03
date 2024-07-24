using phase3.Models;

namespace phase3.FileManager;

public class FileReader
{
    public static List<DataFile> ReadFiles()
    {
        return ReadFilesFromFolder(ReadFolderPath());
    }

    private static string ReadFolderPath()
    {
        return Resources.databasePath;
    }

    private static List<DataFile> ReadFilesFromFolder(string folderPath)
    {
        List<DataFile> data = new();
        var files = Directory.GetFiles(folderPath, "*");
        foreach (var file in files)
            data.Add(new DataFile { FileName = Path.GetFileName(file), Data = File.ReadAllText(file) });
        return data;
    }
}