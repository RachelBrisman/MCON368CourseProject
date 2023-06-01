using Microsoft.EntityFrameworkCore;

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
        ListStudentsPerShiur();

        ListStudentsPerRebbi();

        Console.WriteLine($"\nTotal Number of Shiurim: {db.Shiur.Count()}\n");
    }

    private void ListStudentsPerShiur()
    {
        Console.WriteLine("STATS MODULE - PRESS Q TO RETURN TO PREVIOUS MENU");
        Console.WriteLine("Number of Students Per Shiur");
        foreach (var shiur in db.Shiur)
        {
            Console.WriteLine($"{shiur.Name}: " +
                              $"{db.Student.Count(y => shiur.ShiurID == y.ShiurID)} Students");
        }
    }

    private void ListStudentsPerRebbi()
    {
        Console.WriteLine("\nNumber of Students Per Rebbi:");
        int studentCount;
        foreach (var rebbi in db.Rebbi)
        {
            studentCount = 0;
            if (rebbi.Shiurs == null)
            {
                Console.WriteLine($"{rebbi.Name}: {studentCount} Students");
                break;
            }
            foreach (var shiur in rebbi.Shiurs)
            {
                studentCount += db.Student.Count(x => x.ShiurID == shiur.ShiurID);
            }

            Console.WriteLine($"{rebbi.Name}: {studentCount} Students");
        }
    }
}