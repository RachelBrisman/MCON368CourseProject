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
        var rebbi = ListAndPickARebbi("update");
        
        Console.WriteLine($"Name: {rebbi.Name}");
        if (ChooseToUpdateOrKeep() == 1)
        {
            Console.Write("New Name: ");
            rebbi.Name = letter.ChooseString("Name");
        }
        
        Console.WriteLine($"Address: {rebbi.Address}");
        if (ChooseToUpdateOrKeep() == 1)
        {            
            Console.Write("New Address: ");
            rebbi.Address = Console.ReadLine();
        }

        try
        {
            db.SaveChanges();
            Console.WriteLine("Rebbi Updated Successfully!\n");
        }
        catch (Exception e)
        {
            Console.WriteLine("Something went wrong while trying to update the Rebbi.\n");
        }
    }

    public override void delete()
    {
        var rebbi = ListAndPickARebbi("delete");

        try
        {
            db.Rebbi.Remove(rebbi);
            db.SaveChanges();
            Console.WriteLine("Rebbi deleted successfully!\n");
        }
        catch (Exception e)
        {
            Console.WriteLine("Something went wrong while trying to delete the Rebbi.\n");
        }
    }

    private int ChooseToUpdateOrKeep()
    {
        Console.WriteLine("1. Update\n2. Keep");
        var choice = number.ChooseNumber(2);
        return choice;
    }

    private Rebbi ListAndPickARebbi(string action)
    {
        Console.WriteLine("Rebbis:");
        var count = 1;
        foreach (var r in db.Rebbi)
        {
            Console.WriteLine($"{count}. {r.Name}");
            count++;
        }

        Console.WriteLine($"Which Rebbi would you like to {action}?");
        var rebbiCount = db.Rebbi.Count();
        var rebbi = number.ChooseNumber(rebbiCount);
        return db.Rebbi.ToList()[rebbi];
    }
}