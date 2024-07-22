using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using phase2.Models;

namespace phase2.Processor;

public class PunctuationRemover
{
    public static List<DataFile> RemovePunctuation(List<DataFile> docx)
    {
        var pattern = @"[^A-Za-z0-9]";
        var regex = new Regex(pattern);
        var result = new List<DataFile>();
        foreach (var element in docx)
        {
            result.Add(new DataFile(element.FileName,String.Join(" " ,regex.Split(element.Data))));
        }
        return result;
    }
}