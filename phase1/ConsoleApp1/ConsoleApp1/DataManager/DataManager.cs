namespace ConsoleApp1.DataManager;

public class DataManager
{
    public static List<Student> StudentList(List<ScoreJsonData> scores , List<StudentJsonData> students)
    {
        var listStudent = from student in students
            join score in scores
                on student.StudentNumber equals score.StudentNumber into studentScores
            select new Student(
                student.FirstName,
                student.LastName,
                student.StudentNumber,
                studentScores.ToDictionary(s => s.Lesson, s => (double)s.Score)
            );

        return listStudent.ToList();


    }
}