using MCON368CourseProject.Utils;

namespace MCON368CourseProject.Tasks.AssignAndEnroll;

public class AssignRebbiToShiur
{
    private YeshivaContext db;
    private ListAndPickTypes ListAndPick;

    public AssignRebbiToShiur (YeshivaContext database)
    {
        db = database;
        ListAndPick = new ListAndPickTypes(db);
    }

    public void run()
    {
        Shiur shiur = ListAndPick.AShiur("assign a Rebbi to");
        Rebbi rebbi = ListAndPick.ARebbi($"pick for this {shiur.Name}");
        try
        {
            shiur.Rebbi = rebbi;
            db.SaveChanges();
            Console.WriteLine($"{rebbi.Name} assigned to {shiur.Name} successfully!");
        }
        catch (Exception e)
        {
            Console.WriteLine($"There was a problem assigning {rebbi.Name} to {shiur.Name}");
        }
    }
}