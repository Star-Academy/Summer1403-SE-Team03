namespace phase3.Models;

public class DataFile
{
    public string FileName { get; init; }
    public string Data { get; init; }
    
    public override bool Equals(object? obj)
    {
        var dataFile = (DataFile)obj!;
        return FileName == dataFile.FileName && dataFile.Data == Data;
    }
}