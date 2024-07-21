using System.Text.Json;
using ConsoleApp1;
using System.Xml.Linq;


internal class Program
{
    public static void Main(string[] args)
    {
        string xmlFilePath = @"../../../app.config.xml"; 

        var doc = XDocument.Load(xmlFilePath);

        string pathStudents = doc.Root.Element("filePaths").Element("nameDataFilePath").Value;
        string pathScore = doc.Root.Element("filePaths").Element("scoreDataFilePath").Value;


        
        var persons = ReadFromJson<StudentJsonData>(pathStudents);

        var scores = ReadFromJson<ScoreJsonData>(pathScore);

        var studentList = new List<Student>();
        foreach (var pj in persons)
        {
            var tPerson = new Student(pj.FirstName, pj.LastName, pj.StudentNumber);
            studentList.Add(tPerson);
        }

        var studentArr = studentList.ToArray();

        foreach (var sj in scores) studentArr[sj.StudentNumber - 1].studentGrades.Add(sj.Lesson, sj.Score);

        foreach (var p in studentArr)
            p.GPA = p.studentGrades.Values.Sum() / p.studentGrades.Values.Count;

        var sortedStudent = studentArr.OrderByDescending(p => p.GPA);

        for (var i = 0; i < 3; i++) Console.WriteLine(sortedStudent.ElementAt(i).ToString());
        Console.WriteLine();
    }

    private static List<T> ReadFromJson<T>(string path)
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