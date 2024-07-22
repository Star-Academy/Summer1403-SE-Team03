using System.Resources;
using ConsoleApp1;
using ConsoleApp1.DataManager;

internal class Program
{
    
    public static void Main(string[] args)
    {
        
        ResourceManager rm = new ResourceManager("ConsoleApp1.Properties.Resources", typeof(Program).Assembly);

        string pathStudents = rm.GetString("student");
        string pathScores = rm.GetString("score");
        
        var students = FileManager.ReadFromJson<StudentJsonData>(pathStudents);
        var scores = FileManager.ReadFromJson<ScoreJsonData>(pathScores);
        
        var listStudent = DataManager.GetStudentList(scores, students);

        var university = new University(listStudent.ToList());
        var check = university.CalculateGPA();
        var topStudent = university.GetTopStudent(3);
        foreach (var student in topStudent) Console.WriteLine(student.ToString());
    }
}