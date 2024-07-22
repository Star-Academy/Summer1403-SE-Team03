using System.Xml.Linq;

namespace ConsoleApp1;

public class JsonReader
{
    private static readonly string xmlFilePath = @"../../../app.config.xml";

    public static string ReadJsonFile(string path)
    {
        var doc = XDocument.Load(xmlFilePath);
        return doc.Root.Element("filePaths").Element(path).Value;
    }
}