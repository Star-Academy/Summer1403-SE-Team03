using System.Text;

namespace ConsoleApp1;

public class University
{
    public University(Student[] studentArr)
    {
        StudentArr = studentArr;
    }

    public Student[] StudentArr { get; set; }

    public void CalculateGPA()
    {
        for (var i = 0; i < StudentArr.Length; i++)
            StudentArr[i].GPA = StudentArr[i].studentGrades.Values.Sum() / StudentArr[i].studentGrades.Values.Count;
    }

    public string GetTop3Student()
    {
        var sb = new StringBuilder();
        var sortedStudent = SortStudentArr();
        for (var i = 0; i < 3; i++) sb.Append(sortedStudent.ElementAt(i).ToString() + "\n");

        return sb.ToString();
    }

    private IOrderedEnumerable<Student> SortStudentArr()
    {
        return StudentArr.OrderByDescending(p => p.GPA);
    }
}