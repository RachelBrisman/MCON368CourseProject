using MCON368CourseProject.Utils;

namespace MCON368CourseProject.ManageRecords;

public class RebbiRecordManager : RecordManager
{
    private NumberChooser number = new NumberChooser();
    private StringChooser letter = new StringChooser();
    public YeshivaContext db;

    public RebbiRecordManager(YeshivaContext database)
    {
        db = database;
    }
    
    public override void add()
    {
        var name = letter.ChooseString("Name");
        
        Console.Write("Address: ");
        var address = Console.ReadLine();
        
        try
        {
            db.Rebbi.Add(
                new Rebbi() { Name = name, Address = address}
            );
            db.SaveChanges();
            Console.WriteLine("Rebbi added successfully!\n");
        }
        catch (Exception e)
        {
            Console.WriteLine("There was a problem adding this Rebbi\n.");
        }    }

    public override void update()
    {
        throw new NotImplementedException();
    }

    public override void delete()
    {
        Console.WriteLine("Rebbis:");
        var count = 1;
        foreach (var r in db.Rebbi)
        {
            Console.WriteLine($"{count}. {r.Name}");
            count++;
        }
        Console.WriteLine("Which Rebbi would you like to delete?");
        var rebbiCount = db.Rebbi.Count();
        var rebbi = number.ChooseNumber(rebbiCount);

        try
        {
            db.Rebbi.Remove(db.Rebbi.ToList()[rebbi]);
            Console.WriteLine("Rebbi deleted successfully!\n");
        }
        catch (Exception e)
        {
            Console.WriteLine("Something went wrong while trying to delete the Rebbi.\n");
        }
    }
}