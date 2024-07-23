using System.Collections.Generic;
using System.IO;
using System.Runtime.InteropServices;
using phase2.Models;

namespace phase2.FileManager;

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