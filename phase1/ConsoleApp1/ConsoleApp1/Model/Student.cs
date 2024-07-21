using System.Text;

namespace ConsoleApp1;

public class Student
{
    public Dictionary<string, double> StudentGrades = new();

    public Student(string firstName, string lastName, int id , Dictionary<String,double> studentGrades)
    {
        Id = id;
        FirstName = firstName;
        LastName = lastName;
        StudentGrades = studentGrades;
    }

    public int Id { get; set; }

    public string FirstName { get; set; }

    public string LastName { get; set; }

    public double GPA { get; set; }

    public string ToString()
    {
        return $"Id : {Id} \t - Full name : {FirstName} {LastName} \t - GPA : {GPA} ";
    }
    
    
}