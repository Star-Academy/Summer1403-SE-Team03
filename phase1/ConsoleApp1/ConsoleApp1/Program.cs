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

        var studentList = new List<Student>();
        for (var i = 0; i < persons.Count; i++)
        {
            var tPerson = new Student(persons.ElementAt(i).FirstName, persons.ElementAt(i).LastName,
                persons.ElementAt(i).StudentNumber);
            studentList.Add(tPerson);
        }

        var studentArr = studentList.ToArray();

        for (var i = 0; i < scores.Count; i++)
            studentArr[scores.ElementAt(i).StudentNumber - 1].studentGrades
                .Add(scores.ElementAt(i).Lesson, scores.ElementAt(i).Score);

        var university = new University(studentArr);
        university.CalculateGPA();
        Console.WriteLine(university.GetTop3Student());
    }
}