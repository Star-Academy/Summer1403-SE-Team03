using System.Text.Json;
using ConsoleApp1;

internal class Controller
{
    public static void Main(string[] args)
    {
        // read json file (student data)
        var persons =
            ReadFromJson<PersonJson>(
                @"database\students.json");

        // read json file (score data)
        var scores =
            ReadFromJson<ScoreJson>(
                @"database\scores.json");

        // add persons to studentList with their info 
        var studentList = new List<Person>();
        foreach (var pj in persons)
        {
            var tPerson = new Person(pj.FirstName, pj.LastName, pj.StudentNumber);
            studentList.Add(tPerson);
        }

        // convert list to array to add scores in array with least complexity!
        var studentArr = studentList.ToArray();

        // add grades of each student using StudentNumber
        foreach (var sj in scores) studentArr[sj.StudentNumber - 1].studentGrades.Add(sj.Lesson, sj.Score);

        //calculate GPA
        foreach (var p in studentArr)
            p.GPA = p.studentGrades.Values.Sum() / p.studentGrades.Values.Count;

        // Sort the array with linq 
        var sortedStudent = studentArr.OrderByDescending(p => p.GPA);

        // CW students 
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