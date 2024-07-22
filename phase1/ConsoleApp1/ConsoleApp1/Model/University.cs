namespace ConsoleApp1;

public class University
{
    public University(List<Student> students)
    {
        Students = students;
    }

    public List<Student> Students { get; set; }

    public bool CalculateGPA()
    {
        foreach (var student in Students) student.GPA = student.StudentGrades.Values.Average();
        return true;
    }

    public IEnumerable<Student> GetTopStudent(int count)
    {
        return Students.OrderByDescending(p => p.GPA).Take(count);
    }
}