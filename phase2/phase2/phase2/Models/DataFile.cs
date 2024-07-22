namespace phase2.Models;

public class DataFile
{
    public DataFile(string fileName, string data)
    {
        FileName = fileName;
        Data = data;
    }

    public string FileName { get; set; }
    public string Data { get; set; }
}