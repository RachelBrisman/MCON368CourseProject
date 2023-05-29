namespace MCON368CourseProject.DisplayDetails;

public class RebbiDetailsDisplayer : DetailsDisplayer
{
    public YeshivaContext db;

    public RebbiDetailsDisplayer(YeshivaContext database)
    {
        db = database;
    }

    public override void run()
    {
        foreach (var rebbi in db.Rebbi)
        {
            Console.WriteLine(toString.RebbiToString(rebbi));
        }
    }
}