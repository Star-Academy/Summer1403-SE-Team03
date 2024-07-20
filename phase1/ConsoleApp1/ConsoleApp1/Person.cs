namespace ConsoleApp1;

public class Person
{
    public int id { get; set; }
    
    public String firstName { get; set; }
    
    public String lastName { get; set; }
    
    public Dictionary<string ,double> studentGrades = new Dictionary<string ,double>();
    
    public double GPA { get; set; } 

    public Person(String firstName, string lastName , int id)
    {
        this.id = id;
        this.firstName = firstName;
        this.lastName = lastName;
    }

    public String ToString()
    {
        return $"1) Id : {id} \t - Full name : {firstName} {lastName} \t - GPA : {GPA} ";
    }

}