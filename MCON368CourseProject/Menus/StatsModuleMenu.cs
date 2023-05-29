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
        Console.WriteLine("Number of Students Per Rebbi");
        Console.WriteLine("Total Number of Shiurim");
    }
}