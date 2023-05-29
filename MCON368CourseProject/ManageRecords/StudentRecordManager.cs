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
        var student = ListAndPickAStudent("update");
        
        Console.WriteLine($"Name: {student.Name}");
        if (ChooseToUpdateOrKeep() == 1)
        {
            Console.Write("New Name: ");
            student.Name = letter.ChooseString("Name");
        }
        
        Console.WriteLine($"Address: {student.Address}");
        if (ChooseToUpdateOrKeep() == 1)
        {            
            Console.Write("New Address: ");
            student.Address = Console.ReadLine();
        }
        
        Console.WriteLine($"Shiur: {student.Shiur}");
        if (ChooseToUpdateOrKeep() == 1)
        {            
            Console.WriteLine("Shiurs:");
            var count = 1;
            foreach (var s in db.Shiur)
            {
                Console.WriteLine($"{count}. {s.Name}");
                count++;
            }

            Console.WriteLine("Which Shiur would you like for this Student");
            var shiurCount = db.Shiur.Count();
            var shiur = number.ChooseNumber(shiurCount);
            student.Shiur = db.Shiur.ToList()[shiur];
        }

        try
        {
            db.SaveChanges();
            Console.WriteLine("Student Updated Successfully!\n");
        }
        catch (Exception e)
        {
            Console.WriteLine("Something went wrong while trying to update the Student.\n");
        }    }

    public override void delete()
    {
        var student = ListAndPickAStudent("delete");

        try
        {
            db.Student.Remove(student);
            Console.WriteLine("Student deleted successfully!\n");
        }
        catch (Exception e)
        {
            Console.WriteLine("Something went wrong while trying to delete the Student.\n");
        }
    }
    
    private int ChooseToUpdateOrKeep()
    {
        Console.WriteLine("1. Update\n2. Keep");
        var choice = number.ChooseNumber(2);
        return choice;
    }

    private Student ListAndPickAStudent(string action)
    {
        Console.WriteLine("Students:");
        var count = 1;
        foreach (var s in db.Student)
        {
            Console.WriteLine($"{count}. {s.Name}");
            count++;
        }

        Console.WriteLine($"Which Student would you like to {action}?");
        var studentCount = db.Student.Count();
        var student = number.ChooseNumber(studentCount);
        return db.Student.ToList()[student];
    }
}