using MCON368CourseProject.Utils;

namespace MCON368CourseProject.ManageRecords;

public class ShiurRecordManager : RecordManager
{
    private StringChooser letter = new StringChooser();
    public YeshivaContext db;
    public ListAndPickTypes listAndPick;

    public ShiurRecordManager(YeshivaContext database)
    {
        db = database;        
        listAndPick = new ListAndPickTypes(db);
    }
    
    public override void add()
    {
        Console.Write("Name: ");
        var name = Console.ReadLine();  
        
        Console.Write("Subject: ");
        var subject = Console.ReadLine();
        
        Console.Write("Start Date: ");
        var startDate = Console.ReadLine();

        
        var rebbi = listAndPick.ARebbi("assign to this shiur");

        try
        {
            db.Shiur.Add(
                new Shiur() { Name = name, 
                    Subject = subject, 
                    StartDate = startDate,
                    Rebbi = rebbi}
            );
            db.SaveChanges();
            Console.WriteLine("Shiur added successfully!\n");
        }
        catch (Exception e)
        {
            Console.WriteLine("There was a problem adding this Shiur.\n");
        }    }

    public override void update()
    {
        var shiur = listAndPick.AShiur("update");
        
        Console.WriteLine($"Name: {shiur.Name}");
        if (ChooseToUpdateOrKeep() == 1)
        {
            Console.Write("New Name: ");
            shiur.Name = Console.ReadLine();
        }
        
        Console.WriteLine($"Subject: {shiur.Subject}");
        if (ChooseToUpdateOrKeep() == 1)
        {            
            Console.Write("New Subject: ");
            shiur.Subject = Console.ReadLine();
        }
        
        Console.WriteLine($"Start Date: {shiur.StartDate}");
        if (ChooseToUpdateOrKeep() == 1)
        {            
            Console.Write("New Start Date: ");
            shiur.StartDate = Console.ReadLine();
        }
        
        Console.WriteLine($"Rebbi: {shiur.Rebbi.Name}");
        if (ChooseToUpdateOrKeep() == 1)
        {
            shiur.Rebbi = listAndPick.ARebbi("switch to");
        }

        try
        {
            db.SaveChanges();
            Console.WriteLine("Shiur Updated Successfully!\n");
        }
        catch (Exception e)
        {
            Console.WriteLine("Something went wrong while trying to update the Shiur.\n");
        }    
    }

    public override void delete()
    {
        var shiur = listAndPick.AShiur("delete");
        var studentsInShiur = db.Student.Where(x => x.ShiurID == shiur.ShiurID);
        var defaultShiur = db.Shiur.First().ShiurID;

        try
        {
            foreach (var s in studentsInShiur)
            {
                s.ShiurID = defaultShiur;
            }
            db.Shiur.Remove(shiur);
            db.SaveChanges();
            Console.WriteLine("Shiur deleted successfully!\n");
        }
        catch (Exception e)
        {
            Console.WriteLine("Something went wrong while trying to delete the Shiur\n");
        }
    }
}