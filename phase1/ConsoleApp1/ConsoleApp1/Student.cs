namespace ConsoleApp1;

public class Student
{
    public Dictionary<string, double> studentGrades = new();

    public Student(string firstName, string lastName, int id)
    {
        Id = id;
        FirstName = firstName;
        LastName = lastName;
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