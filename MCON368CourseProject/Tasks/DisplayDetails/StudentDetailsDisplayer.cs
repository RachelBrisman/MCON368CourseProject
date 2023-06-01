using MCON368CourseProject.Utils;

namespace MCON368CourseProject.Tasks.DisplayDetails;


public class StudentDetailsDisplayer
{
    public YeshivaContext db;
    public TypesToString ToString;

    public StudentDetailsDisplayer(YeshivaContext database)
    {
        db = database;
        ToString = new TypesToString(db);
    }

    public void RunSingle(Student student)
    {
        Console.WriteLine(ToString.StudentToString(student));
    }
    
    public void run()
    {
        foreach (var student in db.Student)
        {
            Console.WriteLine(ToString.StudentToString(student));
        }
        Console.WriteLine();
    }
}