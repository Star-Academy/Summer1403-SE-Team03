using System.Runtime.InteropServices.JavaScript;
using System.Xml.Linq;

namespace ConsoleApp1;

public class JsonReader
{
     
    private static String  xmlFilePath = @"../../../app.config.xml";
        

    

    public static String ReadJsonFile(String path)
    {
        var doc = XDocument.Load(xmlFilePath);
        return doc.Root.Element("filePaths").Element(path).Value;
        
    }
}