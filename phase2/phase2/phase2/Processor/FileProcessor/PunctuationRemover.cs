using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using phase2.Models;

namespace phase2.Processor;

public static class PunctuationRemover
{
    public static List<DataFile> RemovePunctuation(this List<DataFile> docx)
    {
        const String pattern = @"[^A-Za-z0-9]";
        var regex = new Regex(pattern);
        var result = new List<DataFile>();
        foreach (var element in docx)
            result.Add(new DataFile
                { FileName = element.FileName, Data = string.Join(" ", regex.Split(element.Data)) });
        return result;
    }
}