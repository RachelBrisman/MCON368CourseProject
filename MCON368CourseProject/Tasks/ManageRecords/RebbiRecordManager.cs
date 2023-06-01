using MCON368CourseProject.Utils;

namespace MCON368CourseProject.ManageRecords;

public class RebbiRecordManager : RecordManager
{
    private StringChooser letter = new StringChooser();
    public YeshivaContext db;
    public ListAndPickTypes listAndPick;

    public RebbiRecordManager(YeshivaContext database)
    {
        db = database;
        listAndPick = new ListAndPickTypes(db);
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
        var rebbi = listAndPick.ARebbi("update");
        
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
        var rebbi = listAndPick.ARebbi("delete");
        var shiursWithRebbi = db.Shiur.Where(x => x.RebbiId == rebbi.RebbiID);
        var defaultRebbi = db.Rebbi.First().RebbiID;

        try
        {
            foreach (var r in shiursWithRebbi)
            {
                r.RebbiId = defaultRebbi;
            }
            db.Rebbi.Remove(rebbi);
            db.SaveChanges();
            Console.WriteLine("Rebbi deleted successfully!\n");
        }
        catch (Exception e)
        {
            Console.WriteLine("Something went wrong while trying to delete the Rebbi.\n");
        }
    }
}