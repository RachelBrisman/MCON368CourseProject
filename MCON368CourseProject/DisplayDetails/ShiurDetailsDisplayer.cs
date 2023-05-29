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
        // add enrolled students
        foreach (var shiur in db.Shiur)
        {
            Console.WriteLine($"Name: {shiur.Name}. Subject: {shiur.Subject}. Start Date: {shiur.StartDate}." +
                              $"Rebbi: {shiur.Rebbi}\n");
        }
    }
}