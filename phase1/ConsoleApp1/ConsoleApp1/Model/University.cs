using System.Text;

namespace ConsoleApp1;

public class University
{
    public University(List<Student> students)
    {
        Students = students;
    }

    public List<Student> Students { get; set; }

    public void CalculateGPA()
    {
        for (var i = 0; i < Students.Count; i++)
            Students.ElementAt(i).GPA = Students.ElementAt(i).StudentGrades.Values.Sum() / Students.ElementAt(i).StudentGrades.Count;
    }

    public IEnumerable<Student> GetTop3Student()
    {
        return Students.OrderByDescending(p => p.GPA).Take(3);
    }


}