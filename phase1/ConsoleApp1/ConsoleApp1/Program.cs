
using System.Text.Json;
using ConsoleApp1;
using System.Linq;

class main
{
    public static void Main(string[] args)
    {
        Person[] student;
        
        List<ScoreJson> scores = new List<ScoreJson>();
        using (StreamReader r = new StreamReader(@"C:\Users\Mahdi\Desktop\code-star\phase1\ConsoleApp1\ConsoleApp1\database\scores.json")) {
                 String json = r.ReadToEnd();
                 scores = JsonSerializer.Deserialize<List<ScoreJson>>(json);
        }   
        // read json file
        List<PersonJson> persons = new List<PersonJson>();
        using (StreamReader r = new StreamReader(@"C:\Users\Mahdi\Desktop\code-star\phase1\ConsoleApp1\ConsoleApp1\database\students.json")) {
            String json = r.ReadToEnd();
            persons = JsonSerializer.Deserialize<List<PersonJson>>(json);
        }
        // read json file


        List<Person> temp = new List<Person>();
        foreach (var person in persons)
        {
            Person tPerson = new Person(person.FirstName, person.LastName, person.StudentNumber);
            temp.Add(tPerson);
        }
        
        student = temp.ToArray(); //convert list to array to add scores in array with least complexity !

        foreach (var person in scores)
        {
            student[person.StudentNumber - 1].studentGrades.Add(person.Lesson, person.Score);
        }

        foreach (var person in student)
        {
            person.GPA = person.studentGrades.Values.Sum() / person.studentGrades.Values.Count;
        } //calculate GPA
        var sortedStudent = student.OrderByDescending(p => p.GPA); 
        // Sort the array with linq 

        for (int i = 0; i < 3; i++)
        {
            Console.WriteLine(sortedStudent.ElementAt(i).ToString());
            
        }
        // CW students 
        
    }
    
}
