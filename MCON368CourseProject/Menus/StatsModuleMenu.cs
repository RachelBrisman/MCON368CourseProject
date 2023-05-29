namespace MCON368CourseProject.Menus;

public class StatsModuleMenu : Menu
{
    public YeshivaContext db;

    public StatsModuleMenu(YeshivaContext database)
    {
        db = database;
    }
    public override void run()
    {
        Console.WriteLine("STATS MODULE - PRESS Q TO RETURN TO PREVIOUS MENU");
        Console.WriteLine("Number of Students Per Shiur");
        foreach (var shiur in db.Shiur)
        {
            Console.WriteLine($"{shiur.Name}: {shiur.Students.Count} Students");
        }
        
        Console.WriteLine("Number of Students Per Rebbi:");
        int studentCount;
        foreach (var rebbi in db.Rebbi)
        {
            studentCount = 0;
            foreach (var shiur in rebbi.Shiurs)
            {
                studentCount += shiur.Students.Count;
            }
            Console.WriteLine($"{rebbi.Name}: {studentCount} Students");
        }
        
        Console.WriteLine($"Total Number of Shiurim: {db.Shiur.Count()}\n");
    }
}