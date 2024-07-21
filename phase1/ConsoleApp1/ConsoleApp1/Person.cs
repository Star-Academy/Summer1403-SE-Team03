namespace ConsoleApp1;

public class Person
{
    public Dictionary<string, double> studentGrades = new();

    public Person(string firstName, string lastName, int id)
    {
        this.id = id;
        this.firstName = firstName;
        this.lastName = lastName;
    }

    public int id { get; set; }

    public string firstName { get; set; }

    public string lastName { get; set; }

    public double GPA { get; set; }

    public string ToString()
    {
        return $"1) Id : {id} \t - Full name : {firstName} {lastName} \t - GPA : {GPA} ";
    }
}