using System.Text.Json;

namespace ConsoleApp1;

public class FileManager
{
    public static List<T> ReadFromJson<T>(String path)
    {
        var list = new List<T>();
        using (var r = new StreamReader(path))
        {
            var json = r.ReadToEnd();
            list = JsonSerializer.Deserialize<List<T>>(json);
        }

        return list;
    }
}