using MCON368CourseProject.Utils;

namespace MCON368CourseProject.Tasks.DisplayDetails;

public class RebbiDetailsDisplayer
{
    public YeshivaContext db;
    public TypesToString ToString;

    public RebbiDetailsDisplayer(YeshivaContext database)
    {
        db = database;
        ToString = new TypesToString(db);
    }

    public void run()
    {
        foreach (var rebbi in db.Rebbi)
        {
            Console.WriteLine(ToString.RebbiToString(rebbi));
        }
        Console.WriteLine();
    }
}