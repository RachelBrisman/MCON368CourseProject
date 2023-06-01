using MCON368CourseProject.Utils;

namespace MCON368CourseProject.Tasks.DisplayDetails;

public class ShiurDetailsDisplayer
{
    public YeshivaContext db;
    public TypesToString ToString;

    public ShiurDetailsDisplayer(YeshivaContext database)
    {
        db = database;
        ToString = new TypesToString(db);
    }

    public void run()
    {
        foreach (var shiur in db.Shiur)
        {
            Console.WriteLine(ToString.ShiurToString(shiur));
        }
        Console.WriteLine();
    }
}