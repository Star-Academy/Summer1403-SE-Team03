using System.Xml.Linq;
using ConsoleApp1;
using ConsoleApp1.DataManager;

internal class Program
{
    public static void Main(string[] args)
    {
        var pathStudents = JsonReader.ReadJsonFile("nameDataFilePath");
        var pathScore = JsonReader.ReadJsonFile("scoreDataFilePath");

        var studentFileManger = new FileManager(pathStudents);
        var scoreFileManger = new FileManager(pathScore);
        
        var students = studentFileManger.ReadFromJson<StudentJsonData>();
        var scores = scoreFileManger.ReadFromJson<ScoreJsonData>();
        
        List<Student> listStudent = DataManager.StudentList(scores, students);
        
        var university = new University(listStudent.ToList());
        university.CalculateGPA();
        var topStudent = university.GetTop3Student();
        foreach(var student in topStudent)
        {
            Console.WriteLine(student.ToString());
        }

    }
}