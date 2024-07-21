using System.Xml.Linq;
using ConsoleApp1;

internal class Program
{
    public static void Main(string[] args)
    {
        var xmlFilePath = @"../../../app.config.xml";

        var doc = XDocument.Load(xmlFilePath);

        var pathStudents = doc.Root.Element("filePaths").Element("nameDataFilePath").Value;
        var pathScore = doc.Root.Element("filePaths").Element("scoreDataFilePath").Value;

        var studentFileManger = new FileManager(pathStudents);

        var persons = studentFileManger.ReadFromJson<StudentJsonData>();

        var scoreFileManger = new FileManager(pathScore);

        var scores = scoreFileManger.ReadFromJson<ScoreJsonData>();

        var listStudent = from person in persons
            join score in scores
                on person.StudentNumber equals score.StudentNumber into studentScores
            select new Student(
                person.FirstName,
                person.LastName,
                person.StudentNumber,
                studentScores.ToDictionary(s => s.Lesson, s => (double)s.Score)
            );
        var university = new University(listStudent.ToList());
        university.CalculateGPA();
        var topStudent = university.GetTop3Student();
        foreach(var student in topStudent)
        {
            Console.WriteLine(student.ToString());
        }

    }
}