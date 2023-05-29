using MCON368CourseProject.Utils;

namespace MCON368CourseProject.ManageRecords;

public class ShiurRecordManager : RecordManager
{
    private NumberChooser number = new NumberChooser();
    private StringChooser letter = new StringChooser();
    public YeshivaContext db;

    public ShiurRecordManager(YeshivaContext database)
    {
        db = database;
    }
    
    public override void add()
    {
        var name = letter.ChooseString("Name");
        
        Console.Write("Subject: ");
        var subject = Console.ReadLine();
        
        Console.Write("Start Date: ");
        var startDate = Console.ReadLine();

        Console.WriteLine("Which Rebbi?: ");
        var count = 1;
        foreach (var r in db.Rebbi)
        {
            Console.WriteLine($"{count}. {r.Name}");
            count++;
        }
        Console.WriteLine("Which Rebbi teaches this shiur?");
        var rebbiCount = db.Rebbi.Count();
        var rebbi = number.ChooseNumber(rebbiCount);

        try
        {
            db.Shiur.Add(
                new Shiur() { Name = name, 
                    Subject = subject, 
                    StartDate = startDate,
                    Rebbi = db.Rebbi.ToList()[rebbi]}
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
        var shiur = ListAndPickAShiur("update");
        
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
        
        Console.WriteLine($"Rebbi: {shiur.Rebbi}");
        if (ChooseToUpdateOrKeep() == 1)
        {
            Console.WriteLine("Rebbis:");
            var count = 1;
            foreach (var r in db.Rebbi)
            {
                Console.WriteLine($"{count}. {r.Name}");
                count++;
            }

            Console.WriteLine($"Which Rebbi would you like for this shiur?");
            var rebbiCount = db.Rebbi.Count();
            var rebbi = number.ChooseNumber(rebbiCount);
            shiur.Rebbi = db.Rebbi.ToList()[rebbi];
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
        var shiur = ListAndPickAShiur("delete");

        try
        {
            db.Shiur.Remove(shiur);
            Console.WriteLine("Shiur deleted successfully!\n");
        }
        catch (Exception e)
        {
            Console.WriteLine("Something went wrong while trying to delete the Shiur\n");
        }
    }
    
    private int ChooseToUpdateOrKeep()
    {
        Console.WriteLine("1. Update\n2. Keep");
        var choice = number.ChooseNumber(2);
        return choice;
    }

    public Shiur ListAndPickAShiur(string action)
    {
        Console.WriteLine("Shiurs:");
        var count = 1;
        foreach (var s in db.Shiur)
        {
            Console.WriteLine($"{count}. {s.Name}");
            count++;
        }

        Console.WriteLine($"Which Shiur would you like to {action}?");
        var shiurCount = db.Shiur.Count();
        var shiur = number.ChooseNumber(shiurCount);
        return db.Shiur.ToList()[shiur];
    }
}