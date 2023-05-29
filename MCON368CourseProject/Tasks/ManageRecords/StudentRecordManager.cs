using MCON368CourseProject.Utils;

namespace MCON368CourseProject.ManageRecords;

public class StudentRecordManager : RecordManager
{
    private StringChooser letter = new StringChooser();
    public YeshivaContext db;
    public ListAndPickTypes listAndPick;

    public StudentRecordManager(YeshivaContext database)
    {
        db = database;        
        listAndPick = new ListAndPickTypes(db);
    }
    
    public override void add()
    {
        var name = letter.ChooseString("Name");
        
        Console.Write("Address: ");
        var address = Console.ReadLine();

        var shiur = listAndPick.AShiur("to place the student in");

        try
        {
            db.Student.Add(
            new Student { Name = name, 
                               Address = address, 
                               Shiur = shiur}
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
        var student = listAndPick.AStudent("update");
        
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
        
        Console.WriteLine($"Shiur: {student.Shiur.Name}");
        if (ChooseToUpdateOrKeep() == 1)
        {            
            student.Shiur = listAndPick.AShiur("switch to");
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
        var student = listAndPick.AStudent("delete");

        try
        {
            db.Student.Remove(student);
            db.SaveChanges();
            Console.WriteLine("Student deleted successfully!\n");
        }
        catch (Exception e)
        {
            Console.WriteLine("Something went wrong while trying to delete the Student.\n");
        }
    }
}