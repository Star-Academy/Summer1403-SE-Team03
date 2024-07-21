using System.Text.Json;

namespace ConsoleApp1;

public class FileManager
{
    public FileManager(string path)
    {
        this.path = path;
    }

    public string path { get; set; }

    public List<T> ReadFromJson<T>()
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