namespace ConsoleApp1;

public class Student
{
    public Dictionary<string, double> studentGrades = new();

    public Student(string firstName, string lastName, int id)
    {
        this.Id = id;
        this.FirstName = firstName;
        this.LastName = lastName;
    }

    public int Id { get; set; }

    public string FirstName { get; set; }

    public string LastName { get; set; }

    public double GPA { get; set; }

    public string ToString()
    {
        return $"1) Id : {Id} \t - Full name : {FirstName} {LastName} \t - GPA : {GPA} ";
    }
}