using System.Runtime.InteropServices;
using phase2.Models;

namespace phase2.FileManager;

public class FileReader
{
    public static List<DataFile> ReadFiles()
    {
        var folderPath = ReadFolderPath();
        return ReadFilesFromFolder(folderPath);
    }

    private static string ReadFolderPath()
    {
        return Resources.databasePath;
    }

    private static List<DataFile> ReadFilesFromFolder(string folderPath)
    {
        List<DataFile> data = new List<DataFile>();
        var files = Directory.GetFiles(folderPath, "*");
        foreach (var file in files)
        {
            data.Add(new DataFile(Path.GetFileName(file) ,File.ReadAllText(file)));
        }
        return data;
    }
}