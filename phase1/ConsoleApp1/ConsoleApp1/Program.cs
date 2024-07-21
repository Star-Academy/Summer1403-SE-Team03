using ConsoleApp1;
using ConsoleApp1.DataManager;

internal class Program
{
    public static void Main(string[] args)
    {
        var pathStudents = JsonReader.ReadJsonFile("nameDataFilePath");
        var pathScore = JsonReader.ReadJsonFile("scoreDataFilePath");

        var students = FileManager.ReadFromJson<StudentJsonData>(pathStudents);
        var scores = FileManager.ReadFromJson<ScoreJsonData>(pathScore);

        var listStudent = DataManager.GetStudentList(scores, students);

        var university = new University(listStudent.ToList());
        var check = university.CalculateGPA();
        var topStudent = university.GetTopStudent(3);
        foreach (var student in topStudent) Console.WriteLine(student.ToString());
    }
}