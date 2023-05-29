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
        throw new NotImplementedException();
    }

    public override void delete()
    {
        Console.WriteLine("Shiurs:");
        var count = 1;
        foreach (var s in db.Shiur)
        {
            Console.WriteLine($"{count}. {s.Name}");
            count++;
        }
        Console.WriteLine("Which Shiur would you like to delete?");
        var shiurCount = db.Shiur.Count();
        var shiur = number.ChooseNumber(shiurCount);

        try
        {
            db.Shiur.Remove(db.Shiur.ToList()[shiur]);
            Console.WriteLine("Shiur deleted successfully!\n");
        }
        catch (Exception e)
        {
            Console.WriteLine("Something went wrong while trying to delete the Shiur\n");
        }
    }
}