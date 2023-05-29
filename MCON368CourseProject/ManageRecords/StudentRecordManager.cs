using MCON368CourseProject.Utils;

namespace MCON368CourseProject.ManageRecords;

public class StudentRecordManager : RecordManager
{
    private NumberChooser number = new NumberChooser();
    private StringChooser letter = new StringChooser();
    public YeshivaContext db;

    public StudentRecordManager(YeshivaContext database)
    {
        db = database;
    }
    
    public override void add()
    {
        var name = letter.ChooseString("Name");
        
        Console.Write("Address: ");
        var address = Console.ReadLine();

        Console.WriteLine("Shiur Options: ");
        var count = 1;
        foreach (var s in db.Shiur)
        {
            Console.WriteLine($"{count}. {s.Name}");
            count++;
        }
        Console.WriteLine("Which shiur is the student in?");
        var shiurCount = db.Shiur.Count();
        var shiur = number.ChooseNumber(shiurCount);

        try
        {
            db.Student.Add(
            new Student { Name = name, 
                               Address = address, 
                               Shiur = db.Shiur.ToList()[shiur]}
            );
            db.SaveChanges();
            Console.WriteLine("Student added successfully!\n");
        }
        catch (Exception e)
        {
            Console.WriteLine("There was a problem adding this student.");
        }
    }

    public override void update()
    {
        throw new NotImplementedException();
    }

    public override void delete()
    {
        Console.WriteLine("Students:");
        var count = 1;
        foreach (var s in db.Student)
        {
            Console.WriteLine($"{count}. {s.Name}");
            count++;
        }
        Console.WriteLine("Which student would you like to delete?");
        var studentCount = db.Student.Count();
        var student = number.ChooseNumber(studentCount);

        try
        {
            db.Student.Remove(db.Student.ToList()[student]);
            Console.WriteLine("Student deleted successfully!\n");
        }
        catch (Exception e)
        {
            Console.WriteLine("Something went wrong while trying to delete the Student.\n");
        }
    }
}