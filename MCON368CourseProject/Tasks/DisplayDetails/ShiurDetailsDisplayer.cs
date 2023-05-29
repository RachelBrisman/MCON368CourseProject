namespace MCON368CourseProject.DisplayDetails;

public class ShiurDetailsDisplayer : DetailsDisplayer
{
    public YeshivaContext db;

    public ShiurDetailsDisplayer(YeshivaContext database)
    {
        db = database;
    }

    public override void run()
    {
        foreach (var shiur in db.Shiur)
        {
            Console.WriteLine(toString.ShiurToString(shiur));
        }
    }
}